using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor.Experimental.RestService;
using UnityEngine;

//public class AudioM : MonoBehaviour
//{
//    [Header("Instance")]
//    public static AudioM instance;


//    [Header("SFX")]
//    FMOD.ChannelGroup sfxChannelGroup;
   
//    FMOD.Sound[] sfxs;   //사운드를 로드
//    FMOD.Channel[] sfxChannels; //각 사운드를 할당

//    //효과음 로드함수
//    void LoadSFX()
//    {
//        int count = System.Enum.GetValues(typeof(SFX)).Length;

//        sfxChannelGroup = new FMOD.ChannelGroup();
//        sfxChannels = new FMOD.Channel[count];
//        sfxs = new FMOD.Sound[count];


//        for(int i=0; i<count; i++)
//        {
//            string sfxFileName = System.Enum.GetName(typeof(SFX), i);
//            string audioType = "ogg";

//            FMODUnity.RuntimeManager.CoreSystem.createSound(Path.Combine(Application.streamingAssetsPath, "SFXS", sfxFileName + "." + audioType),
//                FMOD.MODE.CREATESAMPLE, out sfxs[i]);
//        }


//        for(int i=0; i<count; i++)
//        {
//            sfxChannels[i].setChannelGroup(sfxChannelGroup);
//        }

//    }

//    //효과음 재생함수
//    public void PalySFX(SFX _sfx, float _volume = 1)
//    {
//        int sfxVolume =1;
//        int masterVolume =1;

//        sfxChannels[(int)_sfx].stop();

//        FMODUnity.RuntimeManager.CoreSystem.playSound(sfxs[(int)_sfx], sfxChannelGroup, false, out sfxChannels[(int)_sfx]);

//        sfxChannels[(int)_sfx].setPaused(true);
//        sfxChannels[(int)_sfx].setVolume((_volume * sfxVolume) * masterVolume);
//        sfxChannels[(int)_sfx].setPaused(false);

//    }

//   //현재 음악이 얼마나 재생되었는지 확인하는 함수
//uint GetTime()
//    {
//        AudioM.instance.musicChannel.getPosition(out uint pos, FMOD.TIMEUNIT.MS);
//        return pos;
//    }

//    //메트로놈 구현코드
//    public void SetMetronome()
//    {
//        //미리 생성해둘 메트로놈바 오브젝트의 개수 변수
//        int preBar = 10;


//        //음악 재생 후 메트로놈이 사직되는 시간을 담은 변수
//        int barTime = time - startDelay;

//        //ticktime = BPS(Beat Per Second)를  MS로 변환시킨 변수
//        //공식 : (60/ 노래 BPM) *1000

//        //currentTick = 현재까지 메트로놈이 얼마나 호출되었는지 카운트변수

//        //음악이 시작될때, tickTime만큼의 시간이 경과될대마다 메트로놈 오브젝트와 효과음을 재생
//        if(onMusicStart && barTime >= tickTime * (currentTick - preBar))
//        {
//            AudioM.instance.PlaySFX(SFX.Metronome);
//            currentTick += 1;
//            currentBar = barPool.Get().gameObject;
//        }



//    }

//    //기준값 Pivot에 tickTime을 나누어 FixedScrollSpeed라는 변수에 값을 할당
//    //이 값을 노트, 메트로놈 바의 이동 로직에 적용시켜 모든 곡의 노트, 바의 속도를 일치 시키도록 함.
//    void SetFixedSpeed()
//    {
//        float pivot = 2000f;
//        fixedScrollSpeed = pivot / tickTime;

//    }

//    void SetSpeed()
//    {
//        SetFixedSpeed = tickTime * fixedScrollSpeed / PlayerData.instance.scrollSpeed;
//        resSpeed = fixedScrollSpeed / PlayerData.instance.scrollSpeed;
//    }



//    //스크롤 속도 변화에 따른 y좌표의 변화
//    //(x로 바꿔서 사용할 것)
//    void GetScrollPos()
//    {
//        float noteStartTime = 1000f;

//        for(float i=0.1f; i<=100.0f; i+=0.1f)
//        {
//            double _time = noteStartTime - (tickTime * i) * tickTime;
//            double yPos = (_time - noteStartTime) / (tickTime * i);
//            scrollPos.Add(yPos);

//        }

//    }



//    //메트로놈 바 이동 로직

//    private void Update()
//    {
//        //메트로놈 바 시작시간 기준 Time 변수
//        double barTime = GameManager.instance.time - GameManager.instance.startDelay;

//        //노트 도착시간
//        double endTime = GameManager.instance.endTime;


//        //곡의 현재 재생시간에 따른 비율을 얻도록 함
//        //tickToTime =  현재까지의 누적된 tickTime
//        double yPos = (barTime - tickToTime) / endTime;



//        //배속
//        double resSpeed = GameManager.instance.resSpeed;


//        //노트 배속 상승, 저하시 y좌표에 더해질 값(빨라질경우 양수, 느려질경우 음수)
//        double scrollYAcc = GameManager.instance.scrollPos[(int)((resSpeed * 10) - 1)] * GameManager.instance.musicOffsetDistance;




//        //모든 변수로 현재 바의 포지션을 구함
//        Vector3 targetVec = new Vector3(transform.position.x, GameManager.instance.spawnLine.position.y - (GameManager.instance.musicOffsetDistance * (float)yPos) + (float)scrollYAcc, 0f);

//        transform.position = targetVec;


//        if(transform.position.y <3.342f && !isDestroy)//메트로놈 풀 반환조건
//        {
//            DestroyBar();
//        }

//    }









//}
