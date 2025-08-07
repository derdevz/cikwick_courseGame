 using Unity.Burst.Intrinsics;
using UnityEngine;
using UnityEngine.Rendering;

public class testingscrip : MonoBehaviour
//int doğal sayılarda, float kesirli ve doğal sayılarda, string metinlerde, bool doğru/yanlıs durumu.
//kodlarda sona ; konur. floatta f de konur. 
{
    int number = 5;
    float anothernuber = 5.5f;
    string text = "Hello World!";
    bool istrue = true;
    //oyun baslamadan önce 1 kere çalışan fonksiyondur
    void Awake()
    {

    }
    //oyun basladıktan sonra 1 kere calısan fonksiyondur.
    void Start()
    {

    }
    //sürekli calısır saniyede 300 kadar felan.
    void Update()
    {

    }
    //buda sürekli calısır ama herkeste aynıdır fps farkından kaynaklanan avantajı önler. mesela fps'i yüksek olan cok zıplarken
    //az olan az birim zıplayabilir bunun gibi hataları önler.
    void FixedUpdate()
    {


    }
    //awake, start, update ve fixedupdate fonksiyonları dısında bizde özel fonksiyon yapabilirz ama onlar gibi tanımlı olmadıgından
    //kendilignden calısmazlar.
    void testfunction()
    {

    }

}

