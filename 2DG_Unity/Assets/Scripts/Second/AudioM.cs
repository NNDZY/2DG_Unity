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
   
//    FMOD.Sound[] sfxs;   //���带 �ε�
//    FMOD.Channel[] sfxChannels; //�� ���带 �Ҵ�

//    //ȿ���� �ε��Լ�
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

//    //ȿ���� ����Լ�
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

//   //���� ������ �󸶳� ����Ǿ����� Ȯ���ϴ� �Լ�
//uint GetTime()
//    {
//        AudioM.instance.musicChannel.getPosition(out uint pos, FMOD.TIMEUNIT.MS);
//        return pos;
//    }

//    //��Ʈ�γ� �����ڵ�
//    public void SetMetronome()
//    {
//        //�̸� �����ص� ��Ʈ�γ�� ������Ʈ�� ���� ����
//        int preBar = 10;


//        //���� ��� �� ��Ʈ�γ��� �����Ǵ� �ð��� ���� ����
//        int barTime = time - startDelay;

//        //ticktime = BPS(Beat Per Second)��  MS�� ��ȯ��Ų ����
//        //���� : (60/ �뷡 BPM) *1000

//        //currentTick = ������� ��Ʈ�γ��� �󸶳� ȣ��Ǿ����� ī��Ʈ����

//        //������ ���۵ɶ�, tickTime��ŭ�� �ð��� ����ɴ븶�� ��Ʈ�γ� ������Ʈ�� ȿ������ ���
//        if(onMusicStart && barTime >= tickTime * (currentTick - preBar))
//        {
//            AudioM.instance.PlaySFX(SFX.Metronome);
//            currentTick += 1;
//            currentBar = barPool.Get().gameObject;
//        }



//    }

//    //���ذ� Pivot�� tickTime�� ������ FixedScrollSpeed��� ������ ���� �Ҵ�
//    //�� ���� ��Ʈ, ��Ʈ�γ� ���� �̵� ������ ������� ��� ���� ��Ʈ, ���� �ӵ��� ��ġ ��Ű���� ��.
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



//    //��ũ�� �ӵ� ��ȭ�� ���� y��ǥ�� ��ȭ
//    //(x�� �ٲ㼭 ����� ��)
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



//    //��Ʈ�γ� �� �̵� ����

//    private void Update()
//    {
//        //��Ʈ�γ� �� ���۽ð� ���� Time ����
//        double barTime = GameManager.instance.time - GameManager.instance.startDelay;

//        //��Ʈ �����ð�
//        double endTime = GameManager.instance.endTime;


//        //���� ���� ����ð��� ���� ������ �򵵷� ��
//        //tickToTime =  ��������� ������ tickTime
//        double yPos = (barTime - tickToTime) / endTime;



//        //���
//        double resSpeed = GameManager.instance.resSpeed;


//        //��Ʈ ��� ���, ���Ͻ� y��ǥ�� ������ ��(��������� ���, ��������� ����)
//        double scrollYAcc = GameManager.instance.scrollPos[(int)((resSpeed * 10) - 1)] * GameManager.instance.musicOffsetDistance;




//        //��� ������ ���� ���� �������� ����
//        Vector3 targetVec = new Vector3(transform.position.x, GameManager.instance.spawnLine.position.y - (GameManager.instance.musicOffsetDistance * (float)yPos) + (float)scrollYAcc, 0f);

//        transform.position = targetVec;


//        if(transform.position.y <3.342f && !isDestroy)//��Ʈ�γ� Ǯ ��ȯ����
//        {
//            DestroyBar();
//        }

//    }









//}
