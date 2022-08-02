using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace StringFunctions
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Bir metin giriniz: ");
            string mainWord = Console.ReadLine();
            Console.Write("Metninizin uzunluğu: "); Console.Write(stringFuncs.Uzunluk(mainWord));
            Console.WriteLine("\n1-Uzunluk bulma\n2-Büyük harf yapma\n3-Küçük harf yapma\n4-Boşlukları kaldırma\n5-Soldan boşlukları kaldırma\n6-Sağdan boşlukları kaldırma\n7-Substring bulma\n8-Index bulma\n9-Insert\n10-Replace\n11-Remove\n12-split\n13-join\n14-PadLeft\n15-PadRight\n");
            int a = Convert.ToInt32(Console.ReadLine());

            if(a == 1)
            {
                Console.Write("Metninizin uzunluğu:");
                Console.Write(stringFuncs.Uzunluk(mainWord));
            }
            if(a == 2)
            {
                Console.WriteLine(stringFuncs.BuyukHarf(mainWord));
            }
            if(a == 3)
            {
                Console.WriteLine(stringFuncs.KucukHarf(mainWord));
            }
            if(a == 4)
            {
                Console.WriteLine(stringFuncs.BoslukKaldırma(mainWord));
            }
            if(a == 5)
            {
                Console.WriteLine(stringFuncs.BoslukKaldırmaSol(mainWord));
            }
            if(a == 6)
            {
                Console.WriteLine(stringFuncs.BoslukKaldırmaSag(mainWord));
            }            
            if(a == 7)
            {
                Console.Write("Metninizin uzunluğu:");
                Console.Write(stringFuncs.Uzunluk(mainWord));
                Console.WriteLine("Metninizin uzunluğundan fazla bir uzunluk girmemelisiniz!");
                Console.WriteLine("Kaçıncı harften sonra başlasın?");
                int start = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Kaçıncı harfte dursun?");
                int finish = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine(stringFuncs.AltDizi(mainWord, start, finish));
            }
            if(a == 8)
            {
                Console.WriteLine("Cümle içinden neyi arıyorsunuz?");
                string word = Console.ReadLine();
                int index = stringFuncs.Nerede(mainWord, word);
                Console.WriteLine("Kelimenin olduğu index: {0}", index);
            }
            if(a == 9)
            {
                Console.Write("Metninizin uzunluğu:");
                Console.Write(stringFuncs.Uzunluk(mainWord));
                Console.WriteLine("Metninizin uzunluğundan fazla bir uzunluk girmemelisiniz!");
                Console.WriteLine("Ne yerleştirmek istiyorsunuz?");
                string word2 = Console.ReadLine();
                Console.WriteLine("Nereye yerleştirmek istiyorsunuz?");
                int place = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine(stringFuncs.Yerlestir(mainWord, word2, place));
            }
            if(a == 10)
            {
                Console.WriteLine("Neyi değiştirmek istiyorsunuz?");
                string word3 = Console.ReadLine();
                Console.WriteLine("Ne ile değiştirmek istiyorsunuz?");
                string place2 = Console.ReadLine();
                stringFuncs.Degistir(mainWord, word3, place2);
            }
            if(a == 11)
            {
                Console.WriteLine("Neyi çıkarmak istiyorsunuz?");
                string word4 = Console.ReadLine();               
                stringFuncs.Cikar(mainWord, word4);
            }
            if(a == 12)
            {
                Console.WriteLine(stringFuncs.Ayir(mainWord, ' '));
            }
            if(a == 13)
            {
                Console.WriteLine("Ne ile birleştirmek istiyorsunuz?('-','_','*',',','/')");
                char word4 = Convert.ToChar(Console.ReadLine());
                Console.WriteLine(stringFuncs.Birlestir(mainWord, word4));
            }
            if(a == 14)
            {
                Console.WriteLine("Solunu ne ile doldurmak istiyorsunuz?('-','_','*',',','/')");
                char word5 = Convert.ToChar(Console.ReadLine());
                Console.WriteLine("Ne kadar koymak istiyorsunuz?");
                int place3 = Convert.ToInt32(Console.ReadLine());
                stringFuncs.SolDoldur(mainWord, place3, word5);
            }
            if (a == 15)
            {
                Console.WriteLine("Sağını ne ile doldurmak istiyorsunuz?('-','_','*',',','/')");
                char word6 = Convert.ToChar(Console.ReadLine());
                Console.WriteLine("Ne kadar koymak istiyorsunuz?");
                int place4 = Convert.ToInt32(Console.ReadLine());
                stringFuncs.SagDoldur(mainWord, place4, word6);
            }           

        }
    }

    class stringFuncs
    {
        public static int Uzunluk(string word)
        {
            int numberOfLetters = 0;
            foreach (var c in word)
            {
                numberOfLetters++;
            }
                       
            return numberOfLetters;
        }

        public static string BoslukKaldırma(string word)
        {
            int len = stringFuncs.Uzunluk(word);

            int start = 0, end = len - 1;
            string empty = "";
            for(int i = 0; i < len; i++)
            {
                if(!char.IsWhiteSpace(word[i]))
                {
                    start = i;
                    break;
                }
            }
            
            for(int i = start; i <= end; i++)
            {
                empty += word[i];
            }

            
            return empty;

            //return new string(metin2.Where(c => !char.IsWhiteSpace(c)).ToArray()); dynamic func

        }

        public static string BoslukKaldırmaSol(string word)
        {
            
            string result = "";
            bool trimDone = false;

            foreach (var chr in word)
            {
                if (chr == ' ' && !trimDone) continue;
                result = result + chr;
                trimDone = true;
            }

            
            return result;
                        
        }

        public static string BoslukKaldırmaSag(string word)
        {

            string result = "";
            bool trimDone = false;

            char[] reverse = word.ToCharArray();
            Array.Reverse(reverse);

            foreach (var chr in reverse)
            {
                if (chr == ' ' && !trimDone) continue;
                result = result + chr; 
                trimDone = true;
            }

            char[] a = result.ToCharArray();
            Array.Reverse(a);
            string s = new string(a);

            
            return s;

        }

        public static string KucukHarf(string word)
        {
            string cikti = "";
            
            int len = stringFuncs.Uzunluk(word);

            for (int i = 0; i < len; i++)
            {
                if (word[i] >= 'A' && word[i] <= 'Z')
                {
                    cikti += (char)(word[i] - 'A' + 'a');
                }
                else
                    cikti += word[i];
            }
            
            return cikti;
        }

        public static string BuyukHarf(string word)
        {
            string cikti = "";
            int numberOfLetters = 0;
            foreach (var c in word)
            {
                numberOfLetters++;
            }

            for(int i = 0; i < numberOfLetters; i++)
            {
                if (word[i] >= 'a' && word[i] <= 'z')
                {
                    cikti += (char)(word[i] - 'a' + 'A');
                }
                else
                    cikti += word[i];
            }
            
            return cikti;
        }

        public static string AltDizi(string word,int startIndex, int endIndex)
        {
            int len = stringFuncs.Uzunluk(word);                     

            int i;
            for (i = startIndex; i < len; i++) ;
            StringBuilder Temp = new StringBuilder();
            switch (endIndex < i)
            {
                case true:
                    char[] C = word.ToArray();
                    for (int j = startIndex; j <= endIndex; j++)
                    {
                        Temp.Append(C[j]);
                    }
                    break;
            }
            
            return Temp.ToString();

        }

        public static string Yerlestir(string word, string subs, int index)
        {
            int len = stringFuncs.Uzunluk(word);
            string word2 = stringFuncs.AltDizi(word, 0, index) + subs + stringFuncs.AltDizi(word, index + 1, len - 1);
            
            return word2;
        }

        public static ArrayList DegistirHelper(string word)
        {
            char splitWith = ' ';
            int len = stringFuncs.Uzunluk(word);

            ArrayList arraylist = new ArrayList();
            string temp = "";

            for(int i = 0; i < len; i++)
            {
                if (word[i] != splitWith)
                {
                    temp += word[i];
                    if (i == (len - 1))
                        arraylist.Add(temp);
                    continue;
                }
                arraylist.Add(temp);
                temp = "";
            }
            return arraylist;

        }

        public static void Degistir(string word, string toReplace, string replacedWith)
        {          

            ArrayList arraylist = new ArrayList();
            arraylist = stringFuncs.DegistirHelper(word);

            foreach(string item in arraylist)
            {
                if(item == toReplace)
                {
                    Console.Write(replacedWith + ' ');
                }
                else
                {
                    Console.Write(item + ' ');
                }
            }
        }
                                           
        public static string Cikar(string word,string toReplace)
        {
            string word2 = stringFuncs.KucukHarf(word);
            string toReplace2 = stringFuncs.KucukHarf(toReplace);
            

            int len = stringFuncs.Uzunluk(word);
            int len2 = stringFuncs.Uzunluk(toReplace) - 1;

            for (int j = 0; j <= 1; j++)
            {
                int i = stringFuncs.Nerede(word2, toReplace2);
                if (i == -1)
                {
                    break;

                }

                string partBefore = stringFuncs.AltDizi(word, 0, i - 1);
                string partAfter = stringFuncs.AltDizi(word,  (i + len2)+1, len - 1);
                string word3 = partBefore + partAfter;


                return partBefore + partAfter;
            }

            return null;
        }

        public static int Nerede(string word, string sub)
        {
            bool match;

            int numberOfLetters = 0;
            foreach (var d in word)
            {
                numberOfLetters++;
            }

            int numberOfLetters2 = 0;
            foreach (var d in sub)
            {
                numberOfLetters2++;
            }

            for (int i = 0; i < numberOfLetters - numberOfLetters2 + 1; ++i)
            {
                match = true;
                for (int j = 0; j < numberOfLetters2; ++j)
                {
                    if (word[i + j] != sub[j])
                    {
                        match = false;
                        break;
                    }
                }
                if (match)  return i;
            }
            
            return -1;
        }

        public static string Ayir(string word, char splitWith)
        {
            int len = stringFuncs.Uzunluk(word);
            

            ArrayList arrayList = new ArrayList();
            string temp = "";

            for(int i = 0; i < len; i++)
            {
                if (word[i] != splitWith)
                {
                    temp +=  word[i];
                    if(i == (len - 1))
                    
                        arrayList.Add(temp);
                        continue;
                    
                }
                arrayList.Add(temp);
                temp = "";
            }
            foreach (var item in arrayList)
                Console.Write(item + ",");
            
            return null;
        }

        public static string Birlestir(string word, char replaceWith)
        {
        string word2 = "";
            foreach(char item in word)
            {
                if(item == ' ')
                {
                    word2 += replaceWith;
                }
                else
                {
                    word2 += item;
                }
            }
            return word2;

        }

        public static void SolDoldur(string word, int padding, char toPut)
        {
            int len = stringFuncs.Uzunluk(word);

            for(int i = 0;i< len-padding; i++)
            {
                Console.Write(toPut);
            }
            Console.Write(word);
        }

        public static void SagDoldur(string word, int padding, char toPut)
        {
            int len = stringFuncs.Uzunluk(word);

            Console.Write(word);

            for(int i = 0; i<len-padding; i++)
            {
                Console.Write(toPut);
            }
        }

    }

}











