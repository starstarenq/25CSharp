using LEARN_CS;
using Newtonsoft.Json;

// 1. 폴더에서 파일 경로 가져오기
using System.Reflection.Emit;

string folderpath = "C:\\Users\\Administrator\\Desktop\\25CSharp\\LEARN_CS";
string filename = "Item.json";
string fullpath = Path.Combine(folderpath, filename);
Console.WriteLine(fullpath);
// 2. 파일 읽어오기
string text = File.ReadAllText(fullpath);
Console.WriteLine(text);

string folderpath2 = "C:\\Users\\Administrator\\Desktop\\25CSharp\\LEARN_CS";
string filename2 = "Item_2.json";
string fullpath2 = Path.Combine(folderpath2, filename2);
string text2 = File.ReadAllText(fullpath2);
Console.WriteLine(text2);

// 3. 파일을 데이터로 해석하기 => class 만들기

// json 파일 클래스로 변환. -> Nuget - Newtonsoft 다운받음

var ItemDB =  JsonConvert.DeserializeObject<List<Item>>(text);

 Random random = new Random();


int randValue = random.Next(ItemDB.Count);


Item select = ItemDB[randValue];
Item select2 = ItemDB[1];
Item select3 = ItemDB[2];
Item select4 = ItemDB[3];
Item select5 = ItemDB[4];
Console.WriteLine($"Label : {select.LABEL}, " + $" Name : {select.NAME}, " + $"Stat : {select.STAT}, "+ $"Value : {select.VALUE}, "+ $" Price : {select.PRICE}" );
Console.WriteLine($"Label : {select2.LABEL}, " + $" Name : {select2.NAME}, " + $"Stat : {select2.STAT}, "+ $"Value : {select2.VALUE}, "+ $" Price : {select2.PRICE}");
Console.WriteLine($"Label : {select3.LABEL}, " + $" Name : {select3.NAME}, " + $"Stat : {select3.STAT}, "+ $"Value : {select3.VALUE}, "+ $" Price : {select3.PRICE}");
Console.WriteLine($"Label : {select4.LABEL}, " + $" Name : {select4.NAME}, " + $"Stat : {select4.STAT}, "+ $"Value : {select4.VALUE}, "+ $" Price : {select4.PRICE}");
var ItemDB2 = JsonConvert.DeserializeObject<List<Item>>(text2);
Item select6 = ItemDB2[randValue];
Item select7 = ItemDB2[1];
Item select8 = ItemDB2[2];
Item select9 = ItemDB2[3];
Item select0 = ItemDB2[4];
Console.WriteLine($"Label : {select6.LABEL}, " + $" Name : {select6.NAME}, " + $"Stat : {select6.STAT}, "+ $"Value : {select6.VALUE}, "+ $" Price : {select6.PRICE}");
