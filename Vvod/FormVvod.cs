using System;
using System.Text;
using System.Windows.Forms;
using System.IO;


namespace Vvod
{
    public partial class FormVvod : Form
    {
        string[] words;        // массив слов по предложениям

        StreamWriter Record_words;  // описание потока для записи в файл слов
        StreamWriter Record_sentence;  // описание потока для записи в файл предложений


        public FormVvod()
        {         
            InitializeComponent();
            LFileNameF.Text = "Программа работает с:";
            LFileName.Text = @"Файл не выбран";
        } // end Form1()



        // функция разбиение строк на предложения
        private void analize_textbox()
        {
            int i, j;           // подсчет количества строк в Textbox
            string stroka;      // строка для хранения предложений
            string str_rest = "";    // кусок предыдущей строки, не включенный в предложение
            //string str;    // кусок предыдущей строки, не включенный в предложение
            bool flag = false;          // был ли уже встречен знак окончания предложения !, ?, . false - не был встречен знак
            int nomsentence = 0;            // номер предложения

            // считывание TextBoxSentence по строкам

            for (i = 0; i < TextBoxSentence.Lines.Length; i++)

            {


                if ((TextBoxSentence.Lines[i].Trim() == "") && (str_rest != ""))
                {
                    DivideWords(ref str_rest, ref nomsentence);
                }

                stroka = str_rest + ' ' + TextBoxSentence.Lines[i].Trim();      // если предыдущая строка содержит первую часть предложения

                // разбиение считанной строки на предложения
                flag = false;
                str_rest = "";

                // цикл по длине текущей строки + остаток от предыдущей, если имеется
                for (j = 0; j < stroka.Length; j++)
                {

                    if ((j == stroka.Length - 1) && (i == TextBoxSentence.Lines.Length - 1))
                    {

                        str_rest = str_rest + stroka[j];
                        DivideWords(ref str_rest, ref nomsentence);
                        return;
                    }


                    if ((stroka[j] != '!') && (stroka[j] != '?') && (stroka[j] != '.') && (stroka[j] != '…'))
                    {
                        if (flag == false)
                        {
                            str_rest = str_rest + stroka[j];      // формируем предложение

                        } // end if



                        else
                        {
                            if ((stroka[j] != ' ') && (stroka[j] != '»') && (stroka[j] != '"') && (stroka[j] != ')') && (stroka[j] != ','))
                            {

                                if (stroka[j] == stroka.ToUpper()[j])
                                {
                                    // отправляем предложение на разбиение по словам
                                    DivideWords(ref str_rest, ref nomsentence);       // вызов процедуры
                                    str_rest = str_rest + stroka[j];  // "собираем" новое предложение
                                    flag = false;  // обнуляем признак конца предложения
                                }

                                else
                                {
                                    flag = false;        // всречен признак конца предложения
                                    str_rest = str_rest + stroka[j];      // конкатиируем символ конца предложения к предложению для корректной записи в файл для статистики
                                }
                            }


                            else
                            {
                                str_rest = str_rest + stroka[j];      // формируем предлолжение
                            }

                        } // end else
                    }

                    // встречен разделитель предложений 
                    else
                    {
                        flag = true;        // всречен признак конца предложения
                        str_rest = str_rest + stroka[j];      // конкатиируем символ конца предложения к предложению для корректной записи в файл для статистики
                    } // end else


                } // end if

            } // end for j


        } // end analize ()


        // функция разбиение строк на предложения из файла
        private void analize_file()
        {
            int i, j;           // подсчет количества строк в файле
            string stroka;      // строка для хранения предложений
            string str_rest = "";    // кусок предыдущей строки, не включенный в предложение
            //string str;    // кусок предыдущей строки, не включенный в предложение
            bool flag = false;          // был ли уже встречен знак окончания предложения !, ?, . false - не был встречен знак
            int nomsentence = 0;            // номер предложения


            // построчное чтение файла до конца 
            string file = openFileDialog1.FileName;//расположение файла
            LFileName.Text = file;
            string[] lines = File.ReadAllLines(file, Encoding.GetEncoding(1251));//считываем данные
                                                                                 // MessageBox.Show("Файл"+" "+ file+" "+"открыт"); // если нужно сообщение о том что файл открыт 

            for (i = 0; i < lines.Length; i++)

            {

                if ((lines[i].Trim() == "") && (str_rest != ""))
                {
                    DivideWords(ref str_rest, ref nomsentence);
                }

                stroka = str_rest + ' ' + lines[i].Trim();      // если предыдущая строка содержит первую часть предложения

                // разбиение считанной строки на предложения
                flag = false;
                str_rest = "";

                // цикл по длине текущей строки + остаток от предыдущей, если имеется
                for (j = 0; j < stroka.Length; j++)
                {

                    if ((j == stroka.Length - 1) && (i == lines.Length - 1))
                    {

                        str_rest = str_rest + stroka[j];
                        DivideWords(ref str_rest, ref nomsentence);
                        return;
                    }


                    if ((stroka[j] != '!') && (stroka[j] != '?') && (stroka[j] != '.') && (stroka[j] != '…'))
                    {
                        if (flag == false)
                        {
                            str_rest = str_rest + stroka[j];      // формируем предложение

                        } // end if


                        else
                        {
                            if ((stroka[j] != ' ') && (stroka[j] != '»') && (stroka[j] != '"') && (stroka[j] != ')') && (stroka[j] != ','))
                            {

                                if (stroka[j] == stroka.ToUpper()[j])
                                {
                                    // отправляем предложение на разбиение по словам
                                    DivideWords(ref str_rest, ref nomsentence);       // вызов процедуры
                                    str_rest = str_rest + stroka[j];  // "собираем" новое предложение
                                    flag = false;  // обнуляем признак конца предложения
                                }

                                else
                                {
                                    flag = false;        // всречен признак конца предложения
                                    str_rest = str_rest + stroka[j];      // конкатиируем символ конца предложения к предложению для корректной записи в файл для статистики
                                }
                            }


                            else
                            {
                                str_rest = str_rest + stroka[j];      // формируем предлолжение
                            }

                        } // end else
                    }

                    // встречен разделитель предложений 
                    else
                    {
                        flag = true;        // всречен признак конца предложения
                        str_rest = str_rest + stroka[j];      // конкатиируем символ конца предложения к предложению для корректной записи в файл для статистики
                    } // end else


                } // end if

            } // end for j


        } // end analize ()



        // функция деления предложений на слова
        private void DivideWords(ref string str, ref int nomsentence)
        {

            words = str.Split(new char[] { ' ', ' ', '…', '!', '?', '.', ',', ':', ';', '"', '«', '»', '(', ')', '\n', '-', '–', '—', '—', '–', '−', '-', '/', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            if (words.Length != 0)
            {
                nomsentence++;          // номер предложения для отделенного массива слов

                for (int k = 0; k < words.Length; k++)
                {
                    words[k] = words[k].ToLower();  // перевод слова в нижний регистр
                    words[k] = words[k].Trim();

                    //======================================== А Л Г О Р И Т М =============================================================================================================
                    MAIN_ALGORITM(words[k]);
                    //======================================== А Л Г О Р И Т М =============================================================================================================
                    Statictic_Word(MAIN_ALGORITM(words[k]), nomsentence, words[k]);

                    Record_words.Write(words[k]);            //запись результата в файл 
                    Record_words.Write(' ');                 //запись результата в файл 
                    Record_words.WriteLine(nomsentence);     //запись результата в файл 



                } // end for

                Record_sentence.Write(nomsentence);
                Record_sentence.Write(")");
                Record_sentence.WriteLine(str);

            } // end void DivideWords()

            str = "";

        } // end void DivideWords

        // обработка события клика на кнопку - Разбить
        private void ButtonControl_Click(object sender, EventArgs e)
        {
            LFileName.Text = "Текстом с клавиатуры";
            FileStream Fs = new FileStream("Информация по словам.txt",FileMode.Create);
            Fs.Close();
            //sr2 = new StreamWriter("Vivod2");
            Record_words = new StreamWriter("OutWords.txt");
            Record_sentence = new StreamWriter("OutSentence.txt");
            analize_textbox();
            Record_words.Close();
            Record_sentence.Close();


            Form f2 = new FullAnalysis();
            f2.ShowDialog();

        } // end void ButtonControl_Click



        // обработка события клика на кнопку - считывание текста из файла
        private void ButtonReadFile_Click(object sender, EventArgs e)
        {
            //Если диалог отображен и нажата кнопка ОК
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
                return;
            System.IO.StreamReader sr = new System.IO.StreamReader(openFileDialog1.FileName);

            FileStream Fs = new FileStream("Информация по словам.txt", FileMode.Create);
            Fs.Close();

            Record_words = new StreamWriter("TextWords.txt");
            Record_sentence = new StreamWriter("OutSentence.txt");
            analize_file();
            Record_words.Close();
            Record_sentence.Close();

            Form f2 = new FullAnalysis();
            f2.ShowDialog();
        } // end void ButtonReadFile_Click

        static string MAIN_ALGORITM(string word)
        {
            //==============================================
            #region НЕ УКАЗАННЫЕ ЧАСТИ РЕЧИ

            if (!(Chastits(word) == ""))
            {
                return Chastits(word);
            }
            if (!(Predlog(word) == ""))
            {
                return Predlog(word);
            }
            if (!(Mestoim(word) == ""))
            {
                return Mestoim(word);
            }
            if (!(Chislit(word) == ""))
            {
                return Chislit(word);
            }
            if (!(Souz(word) == ""))
            {
                return Souz(word);
            }
            if (word.Length < 3)
            {
                return "Не определилось";
            }


            #endregion
            //===============================================
            //индекс в конце - длина элементов

            //существительные
            string suffix_noun_1;
            string[] suffix_noun_2 = new string[14];
            string[] suffix_noun_3 = new string[22];
            string[] suffix_noun_4 = new string[7];
            string suffix_noun_5;

            string[] ending_noun_1 = new string[10];
            string[] ending_noun_2 = new string[14];

            //прилагательные
            string[] suffix_adj_1 = new string[4];
            string[] suffix_adj_2 = new string[15];
            string[] suffix_adj_3 = new string[9];
            string[] suffix_adj_4 = new string[9];
            string suffix_adj_5;

            string[] ending_adj_2 = new string[19];
            string[] ending_adj_3 = new string[6];

            //глаголы
            string[] ending_verb_1 = new string[3];
            string[] ending_verb_2 = new string[15];
            string[] ending_verb_3 = new string[4];

            string[] suffix_verb_1 = new string[4];
            string[] suffix_verb_2 = new string[5];
            string[] suffix_verb_3 = new string[4];
            string suffix_verb_4;

            int i = 0;

            #region Инициализация массивов suffix_noun

            using (StreamReader sr = new StreamReader("Suffixes_Nouns.txt"))
            {
                //индекс в конце - длина элементов
                suffix_noun_1 = sr.ReadLine();

                reader_from_file(suffix_noun_2, sr);

                reader_from_file(suffix_noun_3, sr);

                reader_from_file(suffix_noun_4, sr);

                suffix_noun_5 = sr.ReadLine();

            }
            #endregion

            #region Инициализация массивов ending_noun

            using (StreamReader sr = new StreamReader("Endings_nouns.txt"))
            {
                //индекс в конце - длина элементов
                reader_from_file(ending_noun_1, sr);

                reader_from_file(ending_noun_2, sr);
            }

            #endregion

            #region Инициализация массивов suffix_adj

            using (StreamReader sr = new StreamReader("Suffixes_adjectives.txt"))
            {
                //индекс в конце - длина элементов

                reader_from_file(suffix_adj_1, sr);

                reader_from_file(suffix_adj_2, sr);

                reader_from_file(suffix_adj_3, sr);

                reader_from_file(suffix_adj_4, sr);

                suffix_adj_5 = sr.ReadLine();
            }

            #endregion

            #region Инициализация массивов ending_adj

            using (StreamReader sr = new StreamReader("Endings_adjectives.txt"))
            {
                //индекс в конце - длина элементов

                reader_from_file(ending_adj_2, sr);

                reader_from_file(ending_adj_3, sr);
            }


            #endregion

            #region Инициализация массива ending_verb


            using (StreamReader sr = new StreamReader("Ending_verbs.txt"))
            {
                //индекс в конце - длина элементов

                reader_from_file(ending_verb_1, sr);

                reader_from_file(ending_verb_2, sr);

                reader_from_file(ending_verb_3, sr);

            }

            #endregion

            #region Инициализация массива suffix_vrb


            using (StreamReader sr = new StreamReader("Suffixes_verbs.txt"))
            {
                //индекс в конце - длина элементов

                reader_from_file(suffix_verb_1, sr);

                reader_from_file(suffix_verb_2, sr);

                reader_from_file(suffix_verb_3, sr);

                suffix_verb_4 = sr.ReadLine();
            }

            #endregion

            #region АЛГОРИТМ

            bool is_nouns_ending = false;
            bool is_adjs_ending = false;
            bool is_vrbs_ending = false;
            bool try_adj = false;
            int index = 0; //длина окончания

            //индекс в конце - длина элементов

            //ОКОНЧАНИЯ СЛОВА
            string ending_word_1 = "" + word[word.Length - 1];
            string ending_word_2 = "" + word[word.Length - 2] + word[word.Length - 1];
            string ending_word_3 = null;
            if (word.Length > 3)
            {
                ending_word_3 = "" + word[word.Length - 3] + word[word.Length - 2] + word[word.Length - 1];
            }



            #region НАРЕЧИЕ?

            if (check_the_adverb(word) == true)
            {
                return "Наречие";
            }
            #endregion



            #region КОСТЫЛИ
            if (ending_word_2 == "ка" || ending_word_2 == "ки" || ending_word_3 == "еча" || ending_word_3 == "лей")
            {
                return "Существительное";
            }
            if (ending_word_2 == "ул")
            {
                System.Random rnd = new System.Random();
                double rand = rnd.NextDouble();
                if (rand > 0.5)
                    return "Глагол";
                else
                {
                    return "Существительное";
                }
            }
            if (ending_word_3 == "ная" || ending_word_3 == "ную" || ending_word_3 == "ной" || ending_word_3 == "кой" || ending_word_3 == "дой")
            {
                return "Прилагательное";
            }
            #endregion

            if(!(word.Length==4 && ending_word_3!=null))
            {
                #region ГЛАГОЛ?
                if (word.Length > 3)
                {
                    if (ending_word_2 == "ть" || ending_word_1 == "л" || ending_word_2 == "ся")
                    {
                        return "Глагол";
                    }

                    //прошедшее время
                    if (ending_word_1 == "а" || ending_word_1 == "и" || ending_word_1 == "о")
                    {

                        string str = "" + word[word.Length - 2];
                        //Debug.Log(str);
                        if (str == "л")
                        {
                            return "Глагол";
                        }
                    }

                    for (i = 0; i < ending_verb_3.Length; i++)
                    {
                        if ((ending_word_3 == ending_verb_3[i]) & (word.Length > 3))
                        {
                            is_vrbs_ending = true;
                            index = 3;
                        }

                    }
                    if (is_vrbs_ending == false)
                    {
                        for (i = 0; i < ending_verb_2.Length; i++)
                        {
                            if (ending_word_2 == ending_verb_2[i])
                            {
                                is_vrbs_ending = true;
                                index = 2;
                            }
                        }
                    }
                    if (is_vrbs_ending == false)
                    {
                        for (i = 0; i < ending_verb_1.Length; i++)
                        {
                            if ((ending_word_1 == ending_verb_1[i]))
                            {
                                is_vrbs_ending = true;
                                index = 1;
                            }

                        }
                    }
                    if (is_vrbs_ending)
                        if (check_the_verb(word, index, suffix_verb_1, suffix_verb_2, suffix_verb_3, suffix_verb_4) == true)
                        {
                            return "Глагол";
                        }



                }

                #endregion
            }  

            #region ДЕЕПРИЧАСТИЕ
            if (ending_word_2 == "сь")
            {
                return "Деепричастие";
            }
            if (word.Length > 4)
            {
                if (Deeprich(word) == true)
                {
                    return "Деепричастие";
                }
            }
            #endregion

            #region ПРИЧАСТИЕ
            if (word.Length > 4)
            {
                if (Prich(word) == true)
                {
                    return "Причастие";
                }
            }


            #endregion


            if (word.Length > 3)
            {
                if (word.Length > 4)
                {
                    #region ПРИЛАГАТЕЛЬНОЕ?
                    if (ending_word_2 == "ый")
                    {
                        return "Прилагательное";
                    }

                    for (i = 0; i < ending_adj_3.Length; i++)
                    {
                        if ((ending_word_3 == ending_adj_3[i]) && (word.Length > 3))
                        {
                            is_adjs_ending = true;
                            index = 3;
                        }

                    }
                    if (is_adjs_ending == false)
                    {
                        for (i = 0; i < ending_adj_2.Length; i++)
                        {
                            if (ending_word_2 == ending_adj_2[i])
                            {
                                is_adjs_ending = true;
                                index = 2;
                            }

                        }
                    }
                    #endregion

                    
                }

                if (!(word.Length == 4 && ending_word_3 != null))
                {
                    #region СУЩЕСТВИТЕЛЬНОЕ?

                    //смотрим по окончанию
                    if (ending_word_3 == "ами" || ending_word_3 == "ями" || ending_word_3 == "ама" || ending_word_3 == "има")
                    {
                        return "Существительное";
                    }

                    for (i = 0; i < ending_noun_2.Length; i++)
                    {
                        //Debug.Log(ending_word_2+" и "+ ending_noun_2[i]);
                        if (ending_word_2 == ending_noun_2[i])
                        {
                            is_nouns_ending = true;
                            index = 2;
                        }
                    }

                    if (is_nouns_ending == false)
                    {
                        for (i = 0; i < ending_noun_1.Length; i++)
                        {
                            if (ending_word_1 == ending_noun_1[i])
                            {
                                is_nouns_ending = true;
                                index = 1;
                            }
                        }
                    }
                    //нулевое окончание
                    if (is_nouns_ending == false)
                    {
                        index = 0;
                    }

                    //теперь проверяем по суффиксам
                    if (check_the_noun(word, index, suffix_noun_1, suffix_noun_2, suffix_noun_3, suffix_noun_4, suffix_noun_5) == true)
                    {
                        return "Существительное";
                    }
                    #endregion
                }
                //сущетсвительное окначиваюющееся на "ь"
                if (ending_word_1 == "ь")
                {
                    return "Существительное";
                }
               
            }







            #endregion

            return "Не определилось";
        }
        //======================================================================================================
        static bool check_the_adverb(string word)//это слово - наречие?
        {
            using (StreamReader sr = new StreamReader("Adverbs.txt"))
            {
                //индекс в конце - длина элементов
                int N = int.Parse(sr.ReadLine());

                for (int i = 0; i < N; i++)
                {
                    if (word == sr.ReadLine())
                    {
                        return true;
                    }
                }

                return false;
            }
        }
        //======================================================================================================
        static void reader_from_file(string[] array, StreamReader sr)// считываем из файла массив
        {
            int N = int.Parse(sr.ReadLine());

            for (int i = 0; i < N; i++)
            {
                array[i] = sr.ReadLine();
            }
        }
        //======================================================================================================
        static bool check_the_noun(string word, int index, string suffix_noun_1, string[] suffix_noun_2, string[] suffix_noun_3, string[] suffix_noun_4, string suffix_noun_5)
        {
            int i;

            string suffix_word_1 = null;
            suffix_word_1 = "" + word[word.Length - 1 - index];
            //Debug.Log(suffix_word_1);
            if (suffix_noun_1 == suffix_word_1)
            {
                return true;
            }

            string suffix_word_2 = null;
            suffix_word_2 = "" + word[word.Length - 2 - index] + word[word.Length - 1 - index];

            for (i = 0; i < suffix_noun_2.Length; i++)
            {
                if (suffix_word_2 == suffix_noun_2[i])
                {
                    return true;
                }
            }

            if (word.Length > 4 + index)
            {
                string suffix_word_3 = null;
                suffix_word_3 = "" + word[word.Length - 3 - index] + word[word.Length - 2 - index] + word[word.Length - 1 - index];

                for (i = 0; i < suffix_noun_3.Length; i++)
                {
                    if (suffix_word_3 == suffix_noun_3[i])
                    {
                        return true;
                    }
                }
            }

            if (word.Length > 5 + index)
            {
                string suffix_word_4 = null;
                suffix_word_4 = "" + word[word.Length - 4 - index] + word[word.Length - 3 - index] + word[word.Length - 2 - index] + word[word.Length - 1 - index];

                for (i = 0; i < suffix_noun_4.Length; i++)
                {
                    if (suffix_word_4 == suffix_noun_4[i])
                    {
                        return true;
                    }
                }
            }

            if (word.Length > 6 + index)
            {
                string suffix_word_5 = null;
                suffix_word_5 = "" + word[word.Length - 5 - index] + word[word.Length - 4 - index] + word[word.Length - 3 - index] + word[word.Length - 2 - index] + word[word.Length - 1 - index];


                if (suffix_word_5 == suffix_noun_5)
                {
                    return true;
                }

            }
            return false;
        }
        //======================================================================================================
        static bool check_the_adjective(string word, int index, string[] suffix_adj_1, string[] suffix_adj_2, string[] suffix_adj_3, string[] suffix_adj_4, string suffix_adj_5)
        {
            int i;

            string suffix_word_1 = null;
            suffix_word_1 = "" + word[word.Length - 1 - index];

            for (i = 0; i < suffix_adj_1.Length; i++)
            {
                if (suffix_word_1 == suffix_adj_1[i])
                {
                    return true;
                }
            }

            string suffix_word_2 = null;
            suffix_word_2 = "" + word[word.Length - 2 - index] + word[word.Length - 1 - index];

            for (i = 0; i < suffix_adj_2.Length; i++)
            {
                if (suffix_word_2 == suffix_adj_2[i])
                {
                    return true;
                }
            }

            if (word.Length > 4 + index)
            {
                string suffix_word_3 = null;
                suffix_word_3 = "" + word[word.Length - 3 - index] + word[word.Length - 2 - index] + word[word.Length - 1 - index];

                for (i = 0; i < suffix_adj_3.Length; i++)
                {
                    if (suffix_word_3 == suffix_adj_3[i])
                    {
                        return true;
                    }
                }
            }

            if (word.Length > 5 + index)
            {
                string suffix_word_4 = null;
                suffix_word_4 = "" + word[word.Length - 4 - index] + word[word.Length - 3 - index] + word[word.Length - 2 - index] + word[word.Length - 1 - index];

                for (i = 0; i < suffix_adj_4.Length; i++)
                {
                    if (suffix_word_4 == suffix_adj_4[i])
                    {
                        return true;
                    }
                }
            }

            if (word.Length > 6 + index)
            {
                string suffix_word_5 = null;
                suffix_word_5 = "" + word[word.Length - 5 - index] + word[word.Length - 4 - index] + word[word.Length - 3 - index] + word[word.Length - 2 - index] + word[word.Length - 1 - index];


                if (suffix_word_5 == suffix_adj_5)
                {
                    return true;
                }

            }
            return false;
        }
        static bool check_the_verb(string word, int index, string[] suffix_1, string[] suffix_2, string[] suffix_3, string suffix_4)
        {
            int i;

            string suffix_word_1 = null;
            suffix_word_1 = "" + word[word.Length - 1 - index];

            for (i = 0; i < suffix_1.Length; i++)
            {
                if (suffix_word_1 == suffix_1[i])
                {
                    return true;
                }
            }

            string suffix_word_2 = null;
            suffix_word_2 = "" + word[word.Length - 2 - index] + word[word.Length - 1 - index];

            for (i = 0; i < suffix_2.Length; i++)
            {
                if (suffix_word_2 == suffix_2[i])
                {
                    return true;
                }
            }

            if (word.Length > 4 + index)
            {
                string suffix_word_3 = null;
                suffix_word_3 = "" + word[word.Length - 3 - index] + word[word.Length - 2 - index] + word[word.Length - 1 - index];

                for (i = 0; i < suffix_3.Length; i++)
                {
                    if (suffix_word_3 == suffix_3[i])
                    {
                        return true;
                    }
                }
            }

            if (word.Length > 5 + index)
            {
                string suffix_word_4 = null;
                suffix_word_4 = "" + word[word.Length - 4 - index] + word[word.Length - 3 - index] + word[word.Length - 2 - index] + word[word.Length - 1 - index];

                if (suffix_word_4 == suffix_4)
                {
                    return true;
                }
            }

            return false;
        }

        //==============================================================ЖЕНЁЁЁЁЁЁЁЁЁЁЁЁК==========================================================================================================
        #region ЧАСТЬ ЖЕНЬКА

        static bool Deeprich(string name)
        {
            bool isk = false; //флаг - наше слово совпало с каким нибудь исключением
            string line;
            StreamReader file = new StreamReader(@"исключения_дееприч.txt", Encoding.Default);
            while ((line = file.ReadLine()) != null)
            {
                //Console.WriteLine(line, "\n");
                if (line == name)
                {
                    isk = true;
                    return true;
                }
            }
            file.Close();

            if (isk == false)
            {
                bool suf = false;
                //проверяем суффиксы из 3 буквы////////////////////////////////////////////////////////////////////////////////
                if (suf == false)
                {
                    string suf3;
                    suf3 = char.ToString(name[name.Length - 3]);
                    suf3 += char.ToString(name[name.Length - 2]);
                    suf3 += char.ToString(name[name.Length - 1]);

                    line = "";
                    StreamReader filesuf3 = new StreamReader(@"суффиксы_дееприч.txt", Encoding.Default);
                    while ((line = filesuf3.ReadLine()) != null)
                    {
                        //Console.WriteLine(line, "\n");
                        if (line == suf3)
                        {
                            suf = true;
                            return true;
                        }
                    }
                    filesuf3.Close();
                }


                //проверяем суффиксы из 2 буквы////////////////////////////////////////////////////////////////////////////////
                if (suf == false)
                {
                    string suf2;
                    suf2 = char.ToString(name[name.Length - 2]);
                    suf2 += char.ToString(name[name.Length - 1]);


                    line = "";
                    StreamReader filesuf2 = new StreamReader(@"суффиксы_дееприч.txt", Encoding.Default);
                    while ((line = filesuf2.ReadLine()) != null)
                    {
                        //Console.WriteLine(line, "\n");
                        if (line == suf2)
                        {
                            suf = true;
                            return true;
                        }
                    }
                    filesuf2.Close();
                }


                //проверяем суффиксы из 1 буквы////////////////////////////////////////////////////////////////////////////////
                if (suf == false)
                {

                    string suf1;
                    suf1 = char.ToString(name[name.Length - 1]);

                    line = "";
                    StreamReader filesuf1 = new StreamReader(@"суффиксы_дееприч.txt", Encoding.Default);
                    while ((line = filesuf1.ReadLine()) != null)
                    {
                        //Console.WriteLine(line, "\n");
                        if (line == suf1)
                        {
                            suf = true;
                            return true;
                        }
                    }
                    filesuf1.Close();
                }
            }
            return false;
        }

        static bool Prich(string name)
        {
            bool isk = false; //флаг - наше слово воспало с каким нибудь исключением
            string line;
            StreamReader file = new StreamReader(@"исключения_прич.txt", Encoding.Default);
            while ((line = file.ReadLine()) != null)
            {
                //Console.WriteLine(line, "\n");
                if (line == name)
                {
                    isk = true;
                    return true;
                }
            }
            file.Close();

            if (isk == false)
            {
                //проверяем окончание////////////////////////////////////////////////////////////////////////////////
                string okonchanie;
                okonchanie = char.ToString(name[name.Length - 2]);
                okonchanie += char.ToString(name[name.Length - 1]);
                //Console.Write("окончание -  ");
                //Console.Write(okonchanie);

                line = "";
                StreamReader fileOkonchaniy = new StreamReader(@"окончания_прич.txt", Encoding.Default);
                while ((line = fileOkonchaniy.ReadLine()) != null)
                {
                    //Console.WriteLine(line, "\n");
                    if (line == okonchanie)
                    {
                        //Console.Write("\nокончание от причастия\n");
                    }
                }
                fileOkonchaniy.Close();


                bool suf = false;
                //проверяем суффиксы из 3 буквы////////////////////////////////////////////////////////////////////////////////
                if (suf == false)
                {
                    string suf3;
                    suf3 = char.ToString(name[name.Length - 5]);
                    suf3 += char.ToString(name[name.Length - 4]);
                    suf3 += char.ToString(name[name.Length - 3]);


                    line = "";
                    StreamReader filesuf3 = new StreamReader(@"суффиксы_прич.txt", Encoding.Default);
                    while ((line = filesuf3.ReadLine()) != null)
                    {
                        //Console.WriteLine(line, "\n");
                        if (line == suf3)
                        {
                            suf = true;
                            return true;
                        }
                    }
                    filesuf3.Close();
                }


                //проверяем суффиксы из 2 буквы////////////////////////////////////////////////////////////////////////////////
                if (suf == false)
                {
                    string suf2;
                    suf2 = char.ToString(name[name.Length - 4]);
                    suf2 += char.ToString(name[name.Length - 3]);


                    line = "";
                    StreamReader filesuf2 = new StreamReader(@"суффиксы_прич.txt", Encoding.Default);
                    while ((line = filesuf2.ReadLine()) != null)
                    {
                        //Console.WriteLine(line, "\n");
                        if (line == suf2)
                        {
                            suf = true;
                            return true;
                        }
                    }
                    filesuf2.Close();
                }


                //проверяем суффиксы из 1 буквы////////////////////////////////////////////////////////////////////////////////
                if (suf == false)
                {

                    string suf1;
                    suf1 = char.ToString(name[name.Length - 3]);

                    line = "";
                    StreamReader filesuf1 = new StreamReader(@"суффиксы_прич.txt", Encoding.Default);
                    while ((line = filesuf1.ReadLine()) != null)
                    {
                        //Console.WriteLine(line, "\n");
                        if (line == suf1)
                        {
                            suf = true;
                            return true;
                        }
                    }
                    filesuf1.Close();
                }
            }
            return false;
        }

        //проверяем частица
        public static string Chastits(string name)
        {
            string line;
            StreamReader file1 = new StreamReader(@"частицы.txt", Encoding.Default);
            while ((line = file1.ReadLine()) != null)
            {
                if (line == name)
                {
                    file1.Close();
                    return ("Частица");
                }
            }
            file1.Close();
            return ("");
        }


        //проверяем союзы
        public static string Souz(string name)
        {
            string line;
            StreamReader file1 = new StreamReader(@"союзы.txt", Encoding.Default);
            while ((line = file1.ReadLine()) != null)
            {
                if (line == name)
                {
                    file1.Close();
                    return ("Союз");
                }
            }
            file1.Close();
            return ("");
        }


        //проверяем предлоги
        public static string Predlog(string name)
        {
            string line;
            StreamReader file1 = new StreamReader(@"предлоги.txt", Encoding.Default);
            while ((line = file1.ReadLine()) != null)
            {
                //Console.WriteLine(line, "\n");
                if (line == name)
                {
                    file1.Close();
                    return ("Предлог");
                }
            }
            file1.Close();
            return ("");
        }


        //проверяем местоимения
        public static string Mestoim(string name)
        {
            string line;
            StreamReader file1 = new StreamReader(@"местоимения.txt", Encoding.Default);
            while ((line = file1.ReadLine()) != null)
            {
                if (line == name)
                {
                    file1.Close();
                    return ("Местоимение");
                }
            }
            file1.Close();
            return ("");
        }


        //проверяем числительные
        public static string Chislit(string name)
        {
            string line;
            StreamReader file1 = new StreamReader(@"числительные.txt", Encoding.Default);
            while ((line = file1.ReadLine()) != null)
            {
                if (line == name)
                {
                    file1.Close();
                    return ("Числительное");
                }
            }
            file1.Close();
            return ("");
        }
        #endregion
        //========================================================================================================================================================================================
        //========================================================================================================================================================================================
        //========================================================================================================================================================================================
        //========================================================================================================================================================================================
        //========================================================================================================================================================================================
        #region Статистика, запись данных о слове
        //Ответственный Сироткин
        //==============================================================================================
        /// <summary>
        /// Метод записи статистики по слову во временный файл программы(File_words_and_part_of_speach.txt).
        /// На вход подается индикатор части речи слова(int), номер предложения(int) и само слово(string).
        /// Формат слова должен быть строчный иначе будет неверно собрана статистика.
        /// 
        /// На выходе получаем файл со статискикой о входном слове.
        /// </summary>
        static void Statictic_Word(string Part_of_speech, int N_sentence, string Word)
        {
            //Для сбора статистики необходимо знать:
            //слово Word
            //часть речи(роль в предложении)  Part_of_speech
            //номер предложения  N_sentence
            //Эти параметры подаются на вход
            //----------------------------
            //Сбор осуществляется путем занесения необходимой информации во временный файл программы.
            string File_info_about_words = "Информация по словам.txt";
            int index_partofspeach = 0;

            switch (Part_of_speech)
            {
                case "Существительное":
                    {
                        index_partofspeach = 1;
                        break;
                    }
                case "Прилагательное":
                    {
                        index_partofspeach = 2;
                        break;
                    }
                case "Числительное":
                    {
                        index_partofspeach = 3;
                        break;
                    }
                case "Местоимение":
                    {
                        index_partofspeach = 4;
                        break;
                    }
                case "Глагол":
                    {
                        index_partofspeach = 5;
                        break;
                    }
                case "Наречие":
                    {
                        index_partofspeach = 6;
                        break;
                    }
                case "Предлог":
                    {
                        index_partofspeach = 7;
                        break;
                    }
                case "Союз":
                    {
                        index_partofspeach = 8;
                        break;
                    }
                case "Частица":
                    {
                        index_partofspeach = 9;
                        break;
                    }
                case "Причастие":
                    {
                        index_partofspeach = 11;
                        break;
                    }
                case "Деепричастие":
                    {
                        index_partofspeach = 12;
                        break;
                    }
            }
            FileStream Fs = new FileStream(File_info_about_words, FileMode.Open, FileAccess.ReadWrite);//открываем поток
            StreamWriter Sw = new StreamWriter(Fs);//открываем потоковый writer

            Fs.Seek(0, SeekOrigin.End);//сдвиг в конец файла
            Sw.WriteLine(Word + "," + N_sentence + "," + index_partofspeach + ".");
            Sw.Close();
            Fs.Close();
        }//Конец метода Statictic
         //------------------------------------------------------------------------------------------
         //-------------------------------------------------------------------------------------------
        #endregion

        private void FormVvod_Load(object sender, EventArgs e)
        {

        }
    } // end class Form

} // end namespace Vvod

