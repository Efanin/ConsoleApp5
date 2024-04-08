using System.Globalization;
using System.Text.RegularExpressions;

string word = @"Святослав,\r\n\r\nДоброжир,\r\n\r\nТихомир,\r\n\r\nРатибор,\r\n\r\nЯрополк,\r\n\r\nГостомысл,\r\n\r\nВелимудр,\r\n\r\nВсеволод,\r\n\r\nБогдан,\r\n\r\nДоброгнева,\r\n\r\nЛюбомила,\r\n\r\nМиролюб,\r\n\r\nСветозар,";

word = Regex.Replace(word, @"\\r\\n\\r\\n", " ");
word = Regex.Replace(word, @",", "");

List<string> words = new List<string>();
words = word.Split(' ').ToList();


/*
List<string> words =  new List<string>() { 
"petr",
"anna",
"misha",
"robert",
"igor",
"vlad",
"alex",
"goga",
"anton"
};
*/

List<string> badwords = new List<string>()
{
    "Светозар",
    "Святослав",
"Доброгнева"
};

words = words.OrderBy(x => x).ToList();
words = words.Select(x => new CultureInfo("", false).TextInfo.ToTitleCase(x)).ToList();

foreach (var item in badwords)
{
    words = words.Where(x => x.ToLower() != item.ToLower()).ToList();
}


foreach (var item in words)
{
    Console.WriteLine(item);
}
Console.WriteLine($"Count max length words: {words.Where(x => x.Length >= 5).Count()}");

Console.WriteLine();



Console.WriteLine(words.Where(x => x.Length == words.Select(x => x.Length).Max()).Max());
