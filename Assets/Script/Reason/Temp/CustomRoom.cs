using System.Collections;
public static class CustomRoom {
    public static string[] keys = {"D","C"};
    //D is Dokkebi
    //C is Quick Join Code
    public static string GetRandomJoinCode(){
        char[] joinCode = new char[6];
        string Alphabetpool = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        string Digitpool = "0123456789";
        string Totalpool = Alphabetpool + Digitpool;
        
        //조건2.첫글자 무조건 영어
        //조건3.숫자 무조건 하나 포함
        //조건4.숫자는 붙어 있지 않음
        //조건5.영어가 숫자보다 많거나 같아야함
        return "";
    }
}