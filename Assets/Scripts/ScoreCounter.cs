using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour {
    float minspeed = 5;
    float _speednow;
    public Slider _slider;
    GameObject _character;
    float _score;
    public Text _text;
    public int timeelapse = 5;
    public float _time = 0;
    /*
     max 1000
     min 0
     a 900~1000
     b 800~900
     c 700~800
     d 600~700
     e 0~600
     每過timeelape秒會加一次分 public可設定
     有addscore跟minusscore兩個public function可加減分
     需綁slider, text可幫可不綁 綁了方便看成績跟等第
     這個script可以放maincamera或其他不滅的gameobject
     update會刷新slider跟text和抓取腳色目前速度(DemoScene)方便計分
     */
	// Use this for initialization
	void Start () {
        
        _score = 0;
        _character = GameObject.Find("character");
	}
	
	// Update is called once per frame
	void Update () {
        _time += Time.deltaTime;
        if (_time >= timeelapse)
        {
            _time = 0;
            addscore();
        }
        checkspeed();
        setslider();
	}
    void checkspeed()
    {
        _speednow = _character.GetComponent<DemoScene>().runSpeed;
    }
    public void setslider()
    {
        _slider.value = _score;
        _text.text = _score.ToString();
        if (_score <= 1000 && _score >= 900) _text.text = "A";
        else if (_score < 900 && _score >= 800) _text.text = "B";
        else if (_score < 800 && _score >= 700) _text.text = "C";
        else if (_score < 700 && _score >= 600) _text.text = "D";
        else _text.text = "E";
    }
    public void addscore()
    {
        _score += (_speednow - minspeed) * 100;
        if (_score > 1000) _score = 1000;
    }
    public void minusscore()
    {
        _score -= 100;
        if (_score < 0) _score = 0;
    }
}
