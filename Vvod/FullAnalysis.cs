/*
 ******************************************************
 * MAI, chair 302. Informatics, 3rd course.
 * 
 * Project type : Form Windows.
 * Project name : ППО
 * Language: C# (MS VS 2015)
 * File name : FullAnalysis.cs
 * 
 * Author : Sirotkin Evgeniy
 ******************************************************
*/

using System;
using System.Windows.Forms;
using System.IO;

namespace Vvod
{
    public partial class FullAnalysis : Form
    {
        int[][] info_word = new int[2][];//Массив под информацию о слове
        int[][] info_word_PartialAnalysis = new int[1][];//Массив под информацию о слове
        int control = 0;
        bool Listbox_control = false;
        public FullAnalysis()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Метод предназначенный для вывода статистики по всему тексту
        /// На вход поступает файлы: Информация по словам.txt.txt
        /// На выходе получаем заполненный массив со словами, которые заносятся в listbox
        /// </summary>
        public void Analysis()
        {
            //Раздел переменных
            int count_of_words = 0;//Кол-во строк в файле
            int Index_file = 0;//индекс в цикле по файлу
            int Index_word = 0;//индекс в цикле по слову
            int Index_massive = 0;//индекс по массиву слов
            int Index_comparison = 0;//индекс в цикле сравнения
            string String_from_file = "";//Переменная для считывания строки из файла
            string Word_from_string_from_file = "";//Переменная под слова из строки
            string File_info_about_words = "Информация по словам.txt";
            bool Flag_comparison = false;//индикатор сравнения
            string[] Words = new string[0];

            //-------------------------------------------------------------------------
            count_of_words = File.ReadAllLines(File_info_about_words).Length;//Подсчитываем кол-во слов
            CountWords.Text = "Количество слов в файле = " + count_of_words;
            //Анализируем файл File_words_and_part_of_speach.txt
            //Заносим каждое слово в массив слов, чтобы в дальнейшем пользователь мог выбрать слово и посмотреть про него необходимую информацию
            //

            FileStream Fs = new FileStream(File_info_about_words, FileMode.Open, FileAccess.ReadWrite);//открываем поток
            StreamReader Sr = new StreamReader(Fs);//открываем потоковый reader


            //******************Проверка файла на наличие данного слова

            Fs.Seek(0, SeekOrigin.Begin);//сдвиг указателя в начало файла

            //Цикл по всем строкам файла, пока не будет найдено совпадение
            while (Index_file < count_of_words)//до тех пор, пока текущая строка < общего кол-ва строк в файле
            {
                String_from_file = Sr.ReadLine();//заносим стороку из файла
                Word_from_string_from_file = "";

                Index_word = 0;
                //Выделяем слово из строки
                while (true)//пока не сработает условие внутри цикла, делай
                {
                    if (String_from_file[Index_word] != ',')//если слово еще кончилось
                        Word_from_string_from_file += String_from_file[Index_word];
                    else
                        break;
                    Index_word++;
                }
                //слово определено

                //Если алгоритм только начал работать
                if (Index_file == 0)
                {
                    Array.Resize(ref Words, Words.Length + 1);//Расширяем массив
                    Words[Words.Length - 1] = Word_from_string_from_file;//записали слово в массив
                }
                else
                {
                    //Цикл по массиву слов
                    Flag_comparison = false;//обнуляем, совпадений нет
                    for (Index_massive = 0; Index_massive < Words.Length; Index_massive++)
                    {
                        //Если слова равны по длине, проверяем посимвольно
                        if (Words[Index_massive].Length == Word_from_string_from_file.Length)
                        {
                            //Сравниваем слова по символам
                            for (Index_comparison = 0; Index_comparison < Index_word; Index_comparison++)
                            {
                                if (Words[Index_massive][Index_comparison] == Word_from_string_from_file[Index_comparison])
                                    Flag_comparison = true;
                                else
                                {
                                    Flag_comparison = false;
                                    break;
                                }
                            }
                            if (Flag_comparison == true)
                            {
                                break;
                            }
                        }//конец если слова равны по длине
                        else
                            Flag_comparison = false;
                    }//Конец цикла по массиву слов

                    //Если нашлось совпадение, записать
                    if (Flag_comparison == false)
                    {
                        Array.Resize(ref Words, Words.Length + 1);//Расширяем массив
                        Words[Words.Length - 1] = Word_from_string_from_file;
                    }
                }//Конец если интерация алгоритма отлична от 0
                Index_file++;
            }//Конец цикла по файлу
            //Закрываем поток
            Sr.Close();
            Fs.Close();

            //------------------------------------------------------------------------------
            //Массив слов заполнен
            listBox_1.Items.Clear();
            listBox_1.Items.AddRange(Words);
        }//Конец Analysis()
        //------------------------------------------------------------------------------------

        //====================================================================================
        /// <summary>
        /// Метод определяющий информацию из файла Информация по словам.txt.txt в которых содержится входное слово
        /// На выходе получаем массив с номерами предложений и ролями выбранного пользователем слова
        /// </summary>
        public void Info_Word(string Word)
        {
            //Раздел переменных
            int Index_file = 0;//индекс в цикле по файлу
            int Index_word = 0;//индекс в цикле по слову
            int Index_comparison = 0;//индекс в цикле сравнения
            string String_from_file = "";//Переменная для считывания строки из файла
            string Word_from_string_from_file = "";//Переменная под слова из строки
            bool Flag_comparison = false;//индикатор сравнения

            info_word[0] = new int[0];//номера предложений
            info_word[1] = new int[0];//часть речи

            int Word_N_sentence = 0;
            int Word_Part_of_speach = 0;

            int count_of_words = 0;//Кол-во строк в файле
            string File_info_about_words = "Информация по словам.txt";
            //-----------------------------------------
            count_of_words = File.ReadAllLines(File_info_about_words).Length;//Подсчитываем кол-во слов
            //ищем слово в файле и запоминаем статистику о нем

            FileStream Fs = new FileStream(File_info_about_words, FileMode.Open, FileAccess.ReadWrite);//открываем поток
            StreamReader Sr = new StreamReader(Fs);//открываем потоковый reader


            Fs.Seek(0, SeekOrigin.Begin);//сдвиг указателя в начало файла

            //Цикл по всем строкам файла, пока не будет найдено совпадение
            while (Index_file < count_of_words)//до тех пор, пока текущая строка < общего кол-ва строк в файле
            {
                String_from_file = Sr.ReadLine();//заносим стороку из файла
                Word_from_string_from_file = "";
                Index_word = 0;

                //Выделяем слово из строки
                while (true)//пока не сработает условие внутри цикла, делай
                {
                    if (String_from_file[Index_word] != ',')//если слово еще кончилось
                        Word_from_string_from_file += String_from_file[Index_word];
                    else
                        break;
                    Index_word++;
                }
                //слово определено
                Flag_comparison = false;//обнуляем, совпадений нет

                //Если слова равны по длине, проверяем посимвольно
                if (Word.Length == Word_from_string_from_file.Length)
                {
                    //Сравниваем слова по символам
                    for (Index_comparison = 0; Index_comparison < Index_word; Index_comparison++)
                    {
                        if (Word[Index_comparison] == Word_from_string_from_file[Index_comparison])
                            Flag_comparison = true;
                        else
                        {
                            Flag_comparison = false;
                            break;
                        }
                    }
                }//конец если слова равны по длине
                else
                    Flag_comparison = false;
                //Если слово найдено, запоминаем строку с данными
                if (Flag_comparison == true)
                {
                    Word_N_sentence = 0;
                    Word_Part_of_speach = 0;
                    Index_word = 0;
                    Word_from_string_from_file = "";
                    //Выделям номер предложения и часть речи
                    while (true)
                    {
                        if (String_from_file[Index_word] != ',')//если слово еще кончилось
                        {
                            Index_word++;
                        }
                        else
                            break;
                    }
                    Index_word++;//перешагиваем запятую
                    while (true)
                    {
                        if (String_from_file[Index_word] != ',')
                            Word_from_string_from_file += String_from_file[Index_word];
                        else
                            break;
                        Index_word++;
                    }

                    Word_N_sentence = Convert.ToInt32(Word_from_string_from_file);
                    Word_from_string_from_file = "";

                    Index_word++;//перешагиваем запятую
                    while (true)
                    {
                        if (String_from_file[Index_word] != '.')
                            Word_from_string_from_file += String_from_file[Index_word];
                        else
                            break;
                        Index_word++;
                    }
                    Word_Part_of_speach = Convert.ToInt32(Word_from_string_from_file);
                    //Конец выделения номера предложения и части речи

                    Array.Resize(ref info_word[0], info_word[0].Length + 1);
                    Array.Resize(ref info_word[1], info_word[1].Length + 1);
                    info_word[0][info_word[0].Length - 1] = Word_N_sentence;
                    info_word[1][info_word[1].Length - 1] = Word_Part_of_speach;
                }
                Index_word = 0;
                Index_file++;
            }//Конец цикла по файлу
            Sr.Close();
            Fs.Close();
        }//Конец Info_Word

         //====================================================================================
         /// <summary>
         /// Метод выводящий информацию о слове и предложения в которых оно используется
         /// </summary>
        public void Show_Sentences()
        {
            int Miss = 0;//не определено
            int Noun = 0;//существительное
            int Adjective = 0;//прилагательное
            int Numeral = 0;//числительное
            int Pronoun = 0;//местоимение
            int Verb = 0;//глагол
            int Adverb = 0;//наречие
            int Prepositions = 0;//предлог
            int Conjunctions = 0;//союз
            int Particle = 0;//частица
            int Interjections = 0;//междометие
            int Participle = 0;//причастие
            int Participle_II = 0;//деепричастие
            //---------------------------------------------
            string File_sentence = "OutSentence.txt";
            int i, j = 0; //индексы для циклов
            //-----------------------------------------
            //цикл для определения процентной статистики частей речи относительно всех слов
            for (i = 0; i < info_word[1].Length; i++)//цикл для определения процентной статистики частей речи относительно всех слов
            {
                switch (info_word[1][i])
                {
                    case 0:
                        Miss++;
                        break;
                    case 1:
                        Noun++;
                        break;
                    case 2:
                        Adjective++;
                        break;
                    case 3:
                        Numeral++;
                        break;
                    case 4:
                        Pronoun++;
                        break;
                    case 5:
                        Verb++;
                        break;
                    case 6:
                        Adverb++;
                        break;
                    case 7:
                        Prepositions++;
                        break;
                    case 8:
                        Conjunctions++;
                        break;
                    case 9:
                        Particle++;
                        break;
                    case 10:
                        Interjections++;
                        break;
                    case 11:
                        Participle++;
                        break;
                    case 12:
                        Participle_II++;
                        break;
                }
            }
            textBox1.Clear();
            textBox1.Text += "Выбранное слово - '" + listBox_1.Text.ToString() + "'";
            //Вызов метода выводящего всю информацию о слове
            //Вызов происходит по всем частям речи для полного анализа
            PrintInfo(Miss, 0);
            PrintInfo(Noun, 1);
            PrintInfo(Adjective, 2);
            PrintInfo(Numeral, 3);
            PrintInfo(Pronoun, 4);
            PrintInfo(Verb, 5);
            PrintInfo(Adverb, 6);
            PrintInfo(Prepositions, 7);
            PrintInfo(Conjunctions, 8);
            PrintInfo(Particle, 9);
            PrintInfo(Interjections, 10);
            PrintInfo(Participle, 11);
            PrintInfo(Participle_II, 12);

            textBox1.Text += "\r\n\r\nСписок предложений:";
            for (i = 0; i < info_word[0].Length; i++)
            {
                FileStream Fs = new FileStream(File_sentence, FileMode.Open, FileAccess.ReadWrite);//открываем поток
                StreamReader Sr = new StreamReader(Fs);//открываем потоковый reader

                j = 0;
                while (j < info_word[0][i] - 1)
                {
                    Sr.ReadLine();
                    j++;
                }
                textBox1.Text += "\r\n" + Sr.ReadLine();

                Sr.Close();
                Fs.Close();
            }
        }//Конец функции Show_Sentences()
        //====================================================================================
        private void button_1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            Amountofpartsofspeach();
            Listbox_control = false;
            Analysis();
        }

        /// <summary>
        /// Метод создает строку с номерами предложений.
        /// </summary>
        /// <param name="Value_Partofspeach">количество предложений в которых слово используется как заданная часть речи</param>
        /// <param name="Partofspeach">часть речи, которой является слово</param>
        /// <returns>возвращает строку с номерами предложений</returns>
        string StringCreator(int Value_Partofspeach, int Partofspeach)
        {
            string S = "";
            int k = 0;//переменная для сокрашения кол-ва сравнений
                      //цикл по массиву содержащий информацию о выбранном слове
            for (int i = 0; i < info_word[1].Length; i++)
            {
                //выставляем условие
                if (info_word[1][i] == Partofspeach)
                {
                    if (k != Value_Partofspeach)
                    {
                        if (k == 0)//записываем первый раз
                            S += info_word[0][i];
                        else
                            S += "," + info_word[0][i];
                        k++;
                    }
                    else
                        break;
                }
            }
            return S;
        }//Конец StringCreator()
         //---------------------------------------------------------------------
         /// <summary>
         /// Метод, непосредственно изменяющий текст в textbox
         /// </summary>
         /// <param name="Value_Partofspeach">количество предложений в которых слово используется как заданная часть речи</param>
         /// <param name="Partofspeach">часть речи, которой является слово</param>
        void PrintInfo(int Value_Partofspeach, int Partofspeach)
        {
            //Если слово используется как заданная часть речи
            if (Value_Partofspeach != 0)
            {
                string NumOfSentences = "";
                string s = "";
                NumOfSentences = StringCreator(Value_Partofspeach, Partofspeach);

                switch (Partofspeach)
                {
                    case 0:
                        s = "не удалось определить часть речи";
                        break;
                    case 1:
                        s = "существительное";
                        break;
                    case 2:
                        s = "прилагательное";
                        break;
                    case 3:
                        s = "числительное";
                        break;
                    case 4:
                        s = "местоимение";
                        break;
                    case 5:
                        s = "глагол";
                        break;
                    case 6:
                        s = "наречие";
                        break;
                    case 7:
                        s = "предлог";
                        break;
                    case 8:
                        s = "союз";
                        break;
                    case 9:
                        s = "частица";
                        break;
                    case 10:
                        s = "междометие";
                        break;
                    case 11:
                        s = "причастие";
                        break;
                    case 12:
                        s = "деепричастие";
                        break;
                }

                if (Value_Partofspeach == 1)
                {
                    textBox1.Text += "\r\nВстречается в тексте " + Value_Partofspeach + " раз." + "\r\nВ предложении " + NumOfSentences + " - " + s + ".";
                }
                else
                {
                    textBox1.Text += "\r\nВстречается в тексте " + Value_Partofspeach + " раз." + "\r\nВ предложениях " + NumOfSentences + " - " + s + ".";
                }
            }
            //конец если используется как существительное
        }

        private void listBox_1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (Listbox_control == false)
            {
                textBox1.Clear();
                Info_Word(listBox_1.Text.ToString());
                Show_Sentences();
            }
            else
            {
                textBox1.Clear();
                Info_Word_Partial(listBox_1.Text.ToString(), control);
                Show_Sentences_Partial(control);
            }
        }
        //======================================================================================================
        //======================================================================================================
        //======================================================================================================
        //======================================================================================================
        //======================================================================================================
        //======================================================================================================
        //======================================================================================================
        //======================================================================================================
        //======================================================================================================
        //===============Particial Analysis=====================================================================
        //==========================================================================================
        /// <summary>
        /// Метод предназначенный для вывода статистики по всему тексту
        /// На вход поступает файлы: 1) Предложения.txt 2)File_words_and_part_of_speach.txt
        /// </summary>
        public void Analysis_Partial(int PartOfSpeach)
        {
            string[] Words = new string[0];//массив слов заданной части речи
            int Index_file = 0;//индекс в цикле по файлу
            int Index_word = 0;//индекс в цикле по слову
            int Index_massive = 0;//индекс по массиву слов
            int Index_comparison = 0;//индекс в цикле сравнения
            string String_from_file = "";//Переменная для считывания строки из файла
            string Word_from_string_from_file = "";//Переменная под слова из строки
            bool Flag_comparison = false;//индикатор сравнения

            string word = "";
            int Word_N_sentence = 0;
            int Word_Part_of_speach = 0;

            int count_of_words = 0;//Кол-во строк в файле
            string File_info_about_words = "Информация по словам.txt";
            //-----------------------------------------
            count_of_words = File.ReadAllLines(File_info_about_words).Length;//Подсчитываем кол-во слов
            //ищем слово в файле и запоминаем статистику о нем

            FileStream Fs = new FileStream(File_info_about_words, FileMode.Open, FileAccess.ReadWrite);//открываем поток
            StreamReader Sr = new StreamReader(Fs);//открываем потоковый 

            Fs.Seek(0, SeekOrigin.Begin);//сдвиг указателя в начало файла

            //Цикл по всем строкам файла, пока не будет найдено совпадение
            while (Index_file < count_of_words)//до тех пор, пока текущая строка < общего кол-ва строк в файле
            {
                String_from_file = Sr.ReadLine();//заносим стороку из файла
                Word_from_string_from_file = "";
                Index_word = 0;

                //Выделяем слово из строки
                while (true)//пока не сработает условие внутри цикла, делай
                {
                    if (String_from_file[Index_word] != ',')//если слово еще кончилось
                        Word_from_string_from_file += String_from_file[Index_word];
                    else
                        break;
                    Index_word++;
                }
                word = Word_from_string_from_file;//записали слово

                //Выделяем номер предложения
                Word_from_string_from_file = "";
                Index_word++;//перешагиваем запятую
                while (true)
                {
                    if (String_from_file[Index_word] != ',')
                        Word_from_string_from_file += String_from_file[Index_word];
                    else
                        break;
                    Index_word++;
                }

                Word_N_sentence = Convert.ToInt32(Word_from_string_from_file);
                Word_from_string_from_file = "";
                //Выделяем часть речи
                Index_word++;//перешагиваем запятую
                while (true)
                {
                    if (String_from_file[Index_word] != '.')
                        Word_from_string_from_file += String_from_file[Index_word];
                    else
                        break;
                    Index_word++;
                }
                Word_Part_of_speach = Convert.ToInt32(Word_from_string_from_file);
                //Конец выделения номера предложения и части речи

                //если слово является выбранной частью речи
                if (Word_Part_of_speach == PartOfSpeach)
                {
                    //ищем совпадения в массиве
                    //если 1-ая итерация
                    if (Index_file == 0)
                    {
                        Array.Resize(ref Words, Words.Length + 1);//Расширяем массив
                        Words[Words.Length - 1] = word;//записали слово в массив
                    }
                    else
                    {
                        //Цикл по массиву слов
                        Flag_comparison = false;//обнуляем, совпадений нет
                        for (Index_massive = 0; Index_massive < Words.Length; Index_massive++)
                        {
                            //Если слова равны по длине, проверяем посимвольно
                            if (Words[Index_massive].Length == word.Length)
                            {
                                //Сравниваем слова по символам
                                for (Index_comparison = 0; Index_comparison < word.Length; Index_comparison++)
                                {
                                    if (Words[Index_massive][Index_comparison] == word[Index_comparison])
                                        Flag_comparison = true;
                                    else
                                    {
                                        Flag_comparison = false;
                                        break;
                                    }
                                }
                                //если нашлось совпадение, прекращаем поиск
                                if (Flag_comparison == true)
                                {
                                    break;
                                }
                            }//конец если слова равны по длине
                            else
                                Flag_comparison = false;
                        }//Конец цикла по массиву слов

                        //запись слова в массив, если оно новое
                        if (Flag_comparison == false)
                        {
                            Array.Resize(ref Words, Words.Length + 1);//Расширяем массив
                            Words[Words.Length - 1] = word;
                        }
                    }//конец если не 1-ая итерация
                }//Конец если слово выбранная часть речи

                Index_file++;
            }//Конец цикла по файлу
            Sr.Close();
            Fs.Close();
            //Массив слов заполнен
            listBox_1.Items.Clear();
            listBox_1.Items.AddRange(Words);
        }//Конец Analysis_Partial()

        //====================================================================================
        /// <summary>
        /// Метод определяющий информацию из файла File_words_and_part_of_speach.txt в которых содержится входное слово
        /// </summary>
        public void Info_Word_Partial(string Word, int PartOfSpeach)
        {
            //Раздел переменных
            int Index_file = 0;//индекс в цикле по файлу
            int Index_word = 0;//индекс в цикле по слову
            int Index_comparison = 0;//индекс в цикле сравнения
            string String_from_file = "";//Переменная для считывания строки из файла
            string Word_from_string_from_file = "";//Переменная под слова из строки
            bool Flag_comparison = false;//индикатор сравнения

            info_word_PartialAnalysis[0] = new int[0];//номера предложений

            string word = "";
            int Word_N_sentence = 0;
            int Word_Part_of_speach = 0;

            int count_of_words = 0;//Кол-во строк в файле
            string File_info_about_words = "Информация по словам.txt";
            //-----------------------------------------
            count_of_words = File.ReadAllLines(File_info_about_words).Length;//Подсчитываем кол-во слов
            //ищем слово в файле и запоминаем статистику о нем

            FileStream Fs = new FileStream(File_info_about_words, FileMode.Open, FileAccess.ReadWrite);//открываем поток
            StreamReader Sr = new StreamReader(Fs);//открываем потоковый reader


            Fs.Seek(0, SeekOrigin.Begin);//сдвиг указателя в начало файла

            //Цикл по всем строкам файла, пока не будет найдено совпадение
            while (Index_file < count_of_words)//до тех пор, пока текущая строка < общего кол-ва строк в файле
            {
                String_from_file = Sr.ReadLine();//заносим стороку из файла
                Word_from_string_from_file = "";
                Index_word = 0;

                //Выделяем слово из строки
                while (true)//пока не сработает условие внутри цикла, делай
                {
                    if (String_from_file[Index_word] != ',')//если слово еще кончилось
                        Word_from_string_from_file += String_from_file[Index_word];
                    else
                        break;
                    Index_word++;
                }
                //слово определено
                Flag_comparison = false;//обнуляем, совпадений нет

                //Если слова равны по длине, проверяем посимвольно
                if (Word.Length == Word_from_string_from_file.Length)
                {
                    //Сравниваем слова по символам
                    for (Index_comparison = 0; Index_comparison < Index_word; Index_comparison++)
                    {
                        if (Word[Index_comparison] == Word_from_string_from_file[Index_comparison])
                            Flag_comparison = true;
                        else
                        {
                            Flag_comparison = false;
                            break;
                        }
                    }
                }//конец если слова равны по длине
                else
                    Flag_comparison = false;

                word = Word_from_string_from_file;//записали слово

                //Выделяем номер предложения
                Word_from_string_from_file = "";
                Index_word++;//перешагиваем запятую
                while (true)
                {
                    if (String_from_file[Index_word] != ',')
                        Word_from_string_from_file += String_from_file[Index_word];
                    else
                        break;
                    Index_word++;
                }

                Word_N_sentence = Convert.ToInt32(Word_from_string_from_file);
                Word_from_string_from_file = "";
                //Выделяем часть речи
                Index_word++;//перешагиваем запятую
                while (true)
                {
                    if (String_from_file[Index_word] != '.')
                        Word_from_string_from_file += String_from_file[Index_word];
                    else
                        break;
                    Index_word++;
                }
                Word_Part_of_speach = Convert.ToInt32(Word_from_string_from_file);
                //Конец выделения номера предложения и части речи

                //Если слово найдено, запоминаем строку с данными
                if (Flag_comparison == true && Word_Part_of_speach == PartOfSpeach)
                {
                    Array.Resize(ref info_word_PartialAnalysis[0], info_word_PartialAnalysis[0].Length + 1);
                    info_word_PartialAnalysis[0][info_word_PartialAnalysis[0].Length - 1] = Word_N_sentence;
                }
                Index_word = 0;
                Index_file++;
            }//Конец цикла по файлу
            Sr.Close();
            Fs.Close();
            //----------------------      
        }//Конец Info_Word_Partial
         //====================================================================================
        public void Show_Sentences_Partial(int PartOfSpeach)
        {
            int Miss = 0;
            int Noun = 0;//существительное
            int Adjective = 0;//прилагательное
            int Numeral = 0;//числительное
            int Pronoun = 0;//местоимение
            int Verb = 0;//глагол
            int Adverb = 0;//наречие
            int Prepositions = 0;//предлог
            int Conjunctions = 0;//союз
            int Particle = 0;//частица
            int Interjections = 0;//междометие
            int Participle = 0;//причастие
            int Participle_II = 0;//деепричастие
            //---------------------------------------------
            string File_sentence = "OutSentence.txt";
            int i, j = 0; //индексы для циклов
            //-----------------------------------------
            //цикл для определения процентной статистики частей речи относительно всех слов
            for (i = 0; i < info_word_PartialAnalysis[0].Length; i++)//цикл для определения процентной статистики частей речи относительно всех слов
            {
                switch (PartOfSpeach)
                {
                    case 0:
                        Miss++;
                        break;
                    case 1:
                        Noun++;
                        break;
                    case 2:
                        Adjective++;
                        break;
                    case 3:
                        Numeral++;
                        break;
                    case 4:
                        Pronoun++;
                        break;
                    case 5:
                        Verb++;
                        break;
                    case 6:
                        Adverb++;
                        break;
                    case 7:
                        Prepositions++;
                        break;
                    case 8:
                        Conjunctions++;
                        break;
                    case 9:
                        Particle++;
                        break;
                    case 10:
                        Interjections++;
                        break;
                    case 11:
                        Participle++;
                        break;
                    case 12:
                        Participle_II++;
                        break;
                }
            }
            textBox1.Clear();
            textBox1.Text += "Выбранное слово - '" + listBox_1.Text.ToString() + "'";
            //Вызов метода выводящего всю информацию о слове
            //Вызов происходит по всем частям речи для полного анализа
            PrintInfo_Partial(Miss, 0);
            PrintInfo_Partial(Noun, 1);
            PrintInfo_Partial(Adjective, 2);
            PrintInfo_Partial(Numeral, 3);
            PrintInfo_Partial(Pronoun, 4);
            PrintInfo_Partial(Verb, 5);
            PrintInfo_Partial(Adverb, 6);
            PrintInfo_Partial(Prepositions, 7);
            PrintInfo_Partial(Conjunctions, 8);
            PrintInfo_Partial(Particle, 9);
            PrintInfo_Partial(Interjections, 10);
            PrintInfo_Partial(Participle, 11);
            PrintInfo_Partial(Participle_II, 12);

            textBox1.Text += "\r\n\r\nСписок предложений:";
            for (i = 0; i < info_word_PartialAnalysis[0].Length; i++)
            {
                FileStream Fs = new FileStream(File_sentence, FileMode.Open, FileAccess.ReadWrite);//открываем поток
                StreamReader Sr = new StreamReader(Fs);//открываем потоковый reader

                j = 0;
                while (j < info_word_PartialAnalysis[0][i] - 1)
                {
                    Sr.ReadLine();
                    j++;
                }
                textBox1.Text += "\r\n" + Sr.ReadLine();

                Sr.Close();
                Fs.Close();
            }

        }//Конец функции Show_Sentences_Partial()
        //====================================================================================
        /// <summary>
        /// Метод создает строку с номерами предложений.
        /// </summary>
        /// <param name="Value_Partofspeach">количество предложений в которых слово используется как заданная часть речи</param>
        /// <param name="Partofspeach">часть речи, которой является слово</param>
        /// <returns>возвращает строку с номерами предложений</returns>
        string StringCreator_Partial(int Value_Partofspeach, int Partofspeach)
        {
            string S = "";
            int k = 0;//переменная для сокрашения кол-ва сравнений
                      //цикл по массиву содержащий информацию о выбранном слове
            for (int i = 0; i < info_word_PartialAnalysis[0].Length; i++)
            {

                if (k != Value_Partofspeach)
                {
                    if (k == 0)//записываем первый раз
                        S += info_word_PartialAnalysis[0][i];
                    else
                        S += "," + info_word_PartialAnalysis[0][i];
                    k++;
                }
                else
                    break;

            }
            return S;
        }//Конец StringCreator_Partial()
        //---------------------------------------------------------------------
        void PrintInfo_Partial(int Value_Partofspeach, int PartofSpeach)
        {
            //Если слово используется как заданная часть речи
            if (Value_Partofspeach != 0)
            {
                string NumOfSentences = "";
                string s = "";
                NumOfSentences = StringCreator_Partial(Value_Partofspeach, PartofSpeach);

                switch (PartofSpeach)
                {
                    case 0:
                        s = "не удалось определить часть речи";
                            break;
                    case 1:
                        s = "существительное";
                        break;
                    case 2:
                        s = "прилагательное";
                        break;
                    case 3:
                        s = "числительное";
                        break;
                    case 4:
                        s = "местоимение";
                        break;
                    case 5:
                        s = "глагол";
                        break;
                    case 6:
                        s = "наречие";
                        break;
                    case 7:
                        s = "предлог";
                        break;
                    case 8:
                        s = "союз";
                        break;
                    case 9:
                        s = "частица";
                        break;
                    case 10:
                        s = "междометие";
                        break;
                    case 11:
                        s = "причастие";
                        break;
                    case 12:
                        s = "деепричастие";
                        break;
                }

                if (Value_Partofspeach == 1)
                {
                    textBox1.Text += "\r\nВстречается в тексте " + Value_Partofspeach + " раз." + "\r\nВ предложении " + NumOfSentences + " - " + s + ".";
                }
                else
                {
                    textBox1.Text += "\r\nВстречается в тексте " + Value_Partofspeach + " раз." + "\r\nВ предложениях " + NumOfSentences + " - " + s + ".";
                }
            }
            //конец если используется как существительное
        }
        //========================================================================
        private void button_Noun_Click(object sender, EventArgs e)
        {
            Listbox_control = true;
            textBox1.Clear();
            control = 1;
            Analysis_Partial(control);
        }
        
        private void button_adjective_Click(object sender, EventArgs e)
        {
            Listbox_control = true;
            textBox1.Clear();
            control = 2;
            Analysis_Partial(control);
        }

        private void button_numeric_Click(object sender, EventArgs e)
        {
            Listbox_control = true;
            textBox1.Clear();
            control = 3;
            Analysis_Partial(control);
        }

        private void button_Pronoun_Click(object sender, EventArgs e)
        {
            Listbox_control = true;
            textBox1.Clear();
            control = 4;
            Analysis_Partial(control);
        }

        private void button_verb_Click(object sender, EventArgs e)
        {
            Listbox_control = true;
            textBox1.Clear();
            control = 5;
            Analysis_Partial(control);
        }

        private void button_Adverb_Click(object sender, EventArgs e)
        {
            Listbox_control = true;
            textBox1.Clear();
            control = 6;
            Analysis_Partial(control);
        }

        private void button_Prepositions_Click(object sender, EventArgs e)
        {
            Listbox_control = true;
            textBox1.Clear();
            control = 7;
            Analysis_Partial(control);
        }

        private void button_Conjunctions_Click(object sender, EventArgs e)
        {
            Listbox_control = true;
            textBox1.Clear();
            control = 8;
            Analysis_Partial(control);
        }

        private void button_Particle_Click(object sender, EventArgs e)
        {
            Listbox_control = true;
            textBox1.Clear();
            control = 9;
            Analysis_Partial(control);
        }

        private void button_Participle_Click(object sender, EventArgs e)
        {
            Listbox_control = true;
            textBox1.Clear();
            control = 11;
            Analysis_Partial(control);
        }

        private void button_Participle_II_Click(object sender, EventArgs e)
        {
            Listbox_control = true;
            textBox1.Clear();
            control = 12;
            Analysis_Partial(control);
        }

        private void button_Miss_Click(object sender, EventArgs e)
        {
            Listbox_control = true;
            textBox1.Clear();
            control = 0;
            Analysis_Partial(control);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            StatusL.Text = "";
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    button_adjective_Click(sender, e);
                    break;
                case 1:
                    button_numeric_Click(sender, e);
                    break;
                case 2:
                    button_Noun_Click(sender, e);
                    break;
                case 3:
                    button_Pronoun_Click(sender, e);
                    break;
                case 4:
                    button_verb_Click(sender, e);
                    break;
                case 5:
                    button_Adverb_Click(sender, e);
                    break;
                case 6:
                    button_Prepositions_Click(sender, e);
                    break;
                case 7:
                    button_Conjunctions_Click(sender, e);
                    break;
                case 8:
                    button_Particle_Click(sender, e);
                    break;
                case 9:
                    button_Participle_Click(sender, e);
                    break;
                case 10:
                    button_Participle_II_Click(sender, e);
                    break;
                case 11:
                    button_Miss_Click(sender, e);
                    break;
            }
        }
        //------------------------------------------------------------------------------------
        //====================================================================================
        //11,01,2016
        /// <summary>
        /// Метод для вывода числовой статистики в текстбокс.
        /// На вход подается файл "Информация по словам.txt".
        /// На выход - заполненый текстбокс.
        /// </summary>
        void Amountofpartsofspeach()
        {
            int Index_file = 0;//индекс в цикле по файлу
            int Index_word = 0;//индекс в цикле по слову
            int count_of_words = 0;//Кол-во строк в файле
            string File_info_about_words = "Информация по словам.txt";
            string String_from_file = "";//Переменная для считывания строки из файла
            string Num_from_string_from_file = "";//Переменная под числа из строки
            int Miss = 0;
            int Noun = 0;
            int Adjective = 0;
            int Numeral = 0;
            int Pronoun = 0;
            int Verb = 0;
            int Adverb = 0;
            int Prepositions = 0;
            int Conjunctions = 0;
            int Particle = 0;
            int Interjections = 0;
            int Participle = 0;
            int Participle_II = 0;

            //-----------------------------------------
            count_of_words = File.ReadAllLines(File_info_about_words).Length;//Подсчитываем кол-во слов
            //ищем слово в файле и запоминаем статистику о нем

            FileStream Fs = new FileStream(File_info_about_words, FileMode.Open, FileAccess.ReadWrite);//открываем поток
            StreamReader Sr = new StreamReader(Fs);//открываем потоковый reader


            Fs.Seek(0, SeekOrigin.Begin);//сдвиг указателя в начало файла

            //Цикл по файлу для определения кол-ва частей разных частей речи относительно всего текста
            for (Index_file = 0; Index_file < count_of_words; Index_file++)
            {
                Index_word = 0;
                String_from_file = "";
                String_from_file = Sr.ReadLine();//заносим стороку из файла
                Num_from_string_from_file = "";

                //Пропускаем слово из строки
                while (true)//пока не сработает условие внутри цикла, делай
                {
                    if (String_from_file[Index_word] != ',')//если слово еще кончилось
                        Index_word++;
                    else
                        break;
                }
                //Пропускаем номер предложения
                Index_word++;//перешагиваем запятую
                while (true)
                {
                    if (String_from_file[Index_word] != ',')
                        Index_word++;
                    else
                        break;
                }
                //Выделяем часть речи
                Index_word++;//перешагиваем запятую
                while (true)
                {
                    if (String_from_file[Index_word] != '.')
                        Num_from_string_from_file += String_from_file[Index_word];
                    else
                        break;
                    Index_word++;
                }
                //Переключател, в котором мы увеличиваем пременные соответствующих частей речи
                switch (Convert.ToInt32(Num_from_string_from_file))
                {
                    case 0:
                        Miss++;
                        break;
                    case 1:
                        Noun++;
                        break;
                    case 2:
                        Adjective++;
                        break;
                    case 3:
                        Numeral++;
                        break;
                    case 4:
                        Pronoun++;
                        break;
                    case 5:
                        Verb++;
                        break;
                    case 6:
                        Adverb++;
                        break;
                    case 7:
                        Prepositions++;
                        break;
                    case 8:
                        Conjunctions++;
                        break;
                    case 9:
                        Particle++;
                        break;
                    case 10:
                        Interjections++;
                        break;
                    case 11:
                        Participle++;
                        break;
                    case 12:
                        Participle_II++;
                        break;
                }
            }//конец цикла по файлу

            Fs.Close();
            Sr.Close();

            textBox1.Clear();
            double n = 0;//переменная для вывода процентов
            int nn = 0;//переменная для цикла
            string s = "";//строка под вывод
            textBox1.Text += "Обнаружено " + count_of_words + " слов в тексте.\r\n\r\n";
            //Переключатель для сокращения кода
            //Присваиваем переменным необходимые значения для писменного вывода
            //Цикл по частям речи
            for (int i = 0; i < 12; i++)
            {
                switch (i)
                {
                    case 0:
                        nn = Miss;
                        s = "Не распознаны ";
                        break;
                    case 1:
                        nn = Noun;
                        s = "Существительные";
                        break;
                    case 2:
                        nn = Adjective;
                        s = "Прилагательные";
                        break;
                    case 3:
                        nn = Numeral;
                        s = "Числительные";
                        break;
                    case 4:
                        nn = Pronoun;
                        s = "Местоимения";
                        break;
                    case 5:
                        nn = Verb;
                        s = "Глаголы";
                        break;
                    case 6:
                        nn = Adverb;
                        s = "Наречия";
                        break;
                    case 7:
                        nn = Prepositions;
                        s = "Предлоги";
                        break;
                    case 8:
                        nn = Conjunctions;
                        s = "Союзы";
                        break;
                    case 9:
                        nn = Particle;
                        s = "Частица";
                        break;
                    case 10:
                        nn = Interjections;
                        s = "Междометие";
                        break;
                    case 11:
                        nn = Participle;
                        s = "Причастие";
                        break;
                    case 12:
                        nn = Participle_II;
                        s = "Деепричастие";
                        break;
                }//Конец Switch()
                //Относительно присвоеного значения делаем вывод
                if (nn != 0)
                {
                    n = (Convert.ToDouble(nn) / Convert.ToDouble(count_of_words)) * 100;//просто перевод в проценты
                    //если только начало - то вывод нераспознанных слов
                    if (i == 0)
                    {
                        //если слов больше 1 данной части речи
                        if (nn > 1)
                            textBox1.Text += s + nn + " слова - " + Math.Round(n, 2) + "% текста.\r\n";
                        else
                            textBox1.Text += s + nn + " слово - " + Math.Round(n, 2) + "% текста.\r\n";
                        continue;
                    }
                    if (nn > 1)
                        textBox1.Text += s + " в количестве " + nn + " слов, составляют " + Math.Round(n, 2) + "% текста.\r\n";
                    else
                        textBox1.Text += s + " в количестве " + nn + " слова, составляют " + Math.Round(n, 2) + "% текста.\r\n";
                }
            }//Конец цикла по частям речи
        }//Конец метода Amountofpartsofspeach()

        private void FullAnalysis_Load(object sender, EventArgs e)
        {
            Amountofpartsofspeach();
        }

        private void button_2_Click(object sender, EventArgs e)
        {
            int Miss = 0;//не определено
            int Noun = 0;//существительное
            int Adjective = 0;//прилагательное
            int Numeral = 0;//числительное
            int Pronoun = 0;//местоимение
            int Verb = 0;//глагол
            int Adverb = 0;//наречие
            int Prepositions = 0;//предлог
            int Conjunctions = 0;//союз
            int Particle = 0;//частица
            int Interjections = 0;//междометие
            int Participle = 0;//причастие
            int Participle_II = 0;//деепричастие
            string File_result = "Result.txt";

            FileStream Fs = new FileStream(File_result, FileMode.Create, FileAccess.ReadWrite);//открываем поток
            StreamWriter Sw = new StreamWriter(Fs);//открываем потоковый writer

            Amountofpartsofspeach();//В текст бокс обновляем информацию, чтобы потом скопировать в файл
            StatusL.Text = "Информация о результатах анализа была сохранена в файл Result.txt";
            Sw.WriteLine(textBox1.Text);//Занесли текст из текстбокса
            Sw.WriteLine("-----------------------------------------------------------------------------------------------------------");
            Sw.WriteLine();
            Sw.WriteLine();
            Analysis();//прогоняем алгоритм
            //Цикл по всем словам, занесенным в listbox формы(Analysis занёс их)
            for (int i = 0; i < listBox_1.Items.Count; i++)
            {
                string S = "";
                S = Convert.ToString(listBox_1.Items[i]);
                Info_Word(S);//собираем стат по текущему слову
                Sw.WriteLine(S);
                //считаем сколько раз слово использовалась как та или иная часть речи
                for (int j = 0; j < info_word[1].Length; j++)
                {
                    switch (info_word[1][j])
                    {
                        case 0:
                            Miss++;
                            break;
                        case 1:
                            Noun++;
                            break;
                        case 2:
                            Adjective++;
                            break;
                        case 3:
                            Numeral++;
                            break;
                        case 4:
                            Pronoun++;
                            break;
                        case 5:
                            Verb++;
                            break;
                        case 6:
                            Adverb++;
                            break;
                        case 7:
                            Prepositions++;
                            break;
                        case 8:
                            Conjunctions++;
                            break;
                        case 9:
                            Particle++;
                            break;
                        case 10:
                            Interjections++;
                            break;
                        case 11:
                            Participle++;
                            break;
                        case 12:
                            Participle_II++;
                            break;
                    }
                }
                //Вывод по порядку, по каждой части речи
                //Все условия означают, если слово использовалось как такая часть речи, то вывод
                if (Miss != 0)
                {
                    Sw.WriteLine("Используется " + Miss + " раз. В предложениях " + StringCreator(Miss, 0) + " - не удалось определить часть речи");
                }
                if (Noun != 0)
                {
                    Sw.WriteLine("Используется " + Noun + " раз. В предложениях " + StringCreator(Noun, 1) + " - существительное.");
                }
                if (Adjective != 0)
                {
                    Sw.WriteLine("Используется " + Adjective + " раз. В предложениях " + StringCreator(Adjective, 2) + " - прилагательное.");
                }
                if (Numeral != 0)
                {
                    Sw.WriteLine("Используется " + Numeral + " раз. В предложениях " + StringCreator(Numeral, 3) + " - числительное.");
                }
                if (Pronoun != 0)
                {
                    Sw.WriteLine("Используется " + Pronoun + " раз. В предложениях " + StringCreator(Pronoun, 4) + " - местоимение.");
                }
                if (Verb != 0)
                {
                    Sw.WriteLine("Используется " + Verb + " раз. В предложениях " + StringCreator(Verb, 5) + " - глагол.");
                }
                if (Adverb != 0)
                {
                    Sw.WriteLine("Используется " + Adverb + " раз. В предложениях " + StringCreator(Adverb, 6) + " - наречие.");
                }
                if (Prepositions != 0)
                {
                    Sw.WriteLine("Используется " + Prepositions + " раз. В предложениях " + StringCreator(Prepositions, 7) + " - предлог.");
                }
                if (Conjunctions != 0)
                {
                    Sw.WriteLine("Используется " + Conjunctions + " раз. В предложениях " + StringCreator(Conjunctions, 8) + " - союз.");
                }
                if (Particle != 0)
                {
                    Sw.WriteLine("Используется " + Particle + " раз. В предложениях " + StringCreator(Particle, 9) + " - частица.");
                }
                if (Interjections != 0)
                {
                    Sw.WriteLine("Используется " + Interjections + " раз. В предложениях " + StringCreator(Interjections, 10) + " - междометие.");
                }
                if (Participle != 0)
                {
                    Sw.WriteLine("Используется " + Participle + " раз. В предложениях " + StringCreator(Participle, 11) + " - причастие.");
                }
                if (Participle_II != 0)
                {
                    Sw.WriteLine("Используется " + Participle_II + " раз. В предложениях " + StringCreator(Participle_II, 12) + " - деепричастие.");
                }
                Sw.WriteLine("-----------------------------------------------------------------------------------------------------------");
                //Обнуляем
                Miss = 0;//не определено
                Noun = 0;//существительное
                Adjective = 0;//прилагательное
                Numeral = 0;//числительное
                Pronoun = 0;//местоимение
                Verb = 0;//глагол
                Adverb = 0;//наречие
                Prepositions = 0;//предлог
                Conjunctions = 0;//союз
                Particle = 0;//частица
                Interjections = 0;//междометие
                Participle = 0;//причастие
                Participle_II = 0;//деепричастие
            }
            //---------------------
            Sw.Close();
        }//Конец Метода записи в файл
    }
}
