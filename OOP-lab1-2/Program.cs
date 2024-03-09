//Реализовать алгоритм Рабина-Карпа поиска подстроки в строке за O(N).
//строка
string s = "hi";
//текст
string t = "hinnnnhinnhi hi";
Console.WriteLine(s);
Console.WriteLine(t);
Console.WriteLine(" ");
int p = 31;
int n = s.Length;
int m = t.Length;

int[] p_pow = new int[m];
p_pow[0] = 1;
for (int i = 1; i < m; i++)
{
    p_pow[i] = p_pow[i - 1] * p;
}

//вычисляем хэш строк
int[] hashs = new int[m];
for (int i = 0; i < m; i++)
{
    hashs[i] = (t[i]-'a'+1) * p_pow[i];
    if (i != 0)
    {
        hashs[i] += hashs[i - 1];
    }

}

int s_hash = 0;
for (int i = 0; i < n; i++)
{
    s_hash+= (s[i] - 'a' + 1) * p_pow[i];
}


//ответ
int cur_h;
for (int i = 0; (i+n-1)<m; i++)
{
    cur_h = hashs[i+n-1];
    if (i != 0)
    {
        cur_h-=hashs[i - 1];
    }
    if (cur_h ==s_hash * p_pow[i])
    {
        Console.WriteLine(i);
    }
}
