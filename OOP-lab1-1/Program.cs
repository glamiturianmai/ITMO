// 1.Реализовать поиск одинаковых строк.
//Дан список строк S[1..n], каждая длиной не более m символов. 
//Требуется найти все повторяющиеся строки и разделить их на группы, чтобы в каждой группе были только одинаковые строки.

List<string> S =  new List<string>() { "aaa", "bab", "aaa", "love", "dove", "love", "dove"};
int m = 5; //символов в строке не более чем 
int n = 7; //всего строк 
foreach (string s in S)
{
    Console.WriteLine(s, S.IndexOf(s));
}

//h = hash(s0..n-1) = s0p + p2s1 + p3s2 +… + pnsn-1
Console.WriteLine();

//возводим в степени
int p = 31; //простое число 
int[] p_pow = new int[m];
p_pow[0] = 1;
for  (int i = 1; i < m; i++)
{
    p_pow[i] = p_pow[i-1]*p;
}

//вычисляем хэш строк
var hashs = new Dictionary<int, int>();
for  (int i = 0; i < n; i++)
{
    hashs[i] = 0;
    for (int j = 0; j < S[i].Length; j++)
    {
        hashs[i] += (S[i][j] - 'a' + 1) * p_pow[j];
    }

}

hashs= hashs.OrderBy(pair=>pair.Value).ToDictionary(pair => pair.Key, pair => pair.Value);
foreach (var item in hashs)
{
    Console.WriteLine($"{item.Key} {item.Value}");
}




int n_groups = 0;
var pervious_hash=hashs.First();
Console.WriteLine(pervious_hash);
foreach (var hash in hashs)
{
    if (hash.Equals(hashs.First()) || hash.Value != pervious_hash.Value)
    {
        n_groups++;
        Console.WriteLine();
        Console.Write("Group {0}:", n_groups);
    }
    Console.Write($"{hash.Key} (hash={hash.Value}) ");
    pervious_hash = hash;
}