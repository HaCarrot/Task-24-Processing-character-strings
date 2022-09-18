using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Diagnostics; 

public class TaskOne : MonoBehaviour
{
	public string desktop_path;
    public string task;
	public string solution;
	public char la,lb,lc;
	public string data = "";
	public TextMesh block,check,remark;
	public int len,type;
    void Start()
    {
		GenerateTask();
    }
	void GenerateTask(){
		type = (int) UnityEngine.Random.Range(1.0f, 3.0f);
		if(type == 1){
			len = 1000;
			data = "";
			desktop_path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
			char[] letters = new char[] {'A','B','C','D','E','F','G','H','K','L'};
			int i = (int) UnityEngine.Random.Range(1.0f, 9.0f);
			task = "В текстовом файле input.txt находится цепочка из символов\nлатинского алфавита " + letters[i-1] + "," + letters[i] + "," + letters[i+1] +". Найдите длину самой длинной подцепочки,\nсостоящей из символов " + letters[i+1] +".";
			block.text = task;
			char[] a = {letters[i-1],letters[i],letters[i+1]};
			while (len > 0){
				len -= 4;
				data = data + a[(int) UnityEngine.Random.Range(0.0f,3.0f)] + a[(int) UnityEngine.Random.Range(0.0f,3.0f)] + a[(int) UnityEngine.Random.Range(0.0f,3.0f)] + a[(int) UnityEngine.Random.Range(0.0f,3.0f)];
			}
			solution = "s = \"\"\nwith open(\"input.txt\",\"r\") as f:\n\ts = f.read()\nmaxLen = 0\ncLen = 0\nfor c in s:\n\tif c == '"+letters[i+1]+"':\n\t\tcLen += 1\n\t\tif cLen > maxLen:\n\t\t\tmaxLen = cLen\n\telse:\n\t\tcLen = 0\nprint(maxLen)";
		}
		if(type == 2){
			len = 1000;
			data = "";
			desktop_path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
			int i = (int) UnityEngine.Random.Range(1.0f, 5.0f);
			char[] a = new char[] {'A','B','C','D','E','F','G','H','K','L','0','1','2','3','4','5','6','7','8','9'};
			while (len > 0){
				len -= 4;
				data = data + a[(int) UnityEngine.Random.Range(0.0f,19.0f)] + a[(int) UnityEngine.Random.Range(0.0f,19.0f)] + a[(int) UnityEngine.Random.Range(0.0f,19.0f)] + a[(int) UnityEngine.Random.Range(0.0f,19.0f)];
			}
			if(i == 1){
				task = "Текстовом файл input.txt состоит не более чем из 1000000 символов.\nОпределите максимальное нечётное число записанное в этом файле.";
				block.text = task;
				solution = "s = \"\"\nwith open(\"input.txt\") as f:\n\ts = f.read()\nans = -1\nnum = ''\nfor i in s:\n\tif(i.isdigit()):\n\t\tnum = num + i\n\telif(num != ''):\n\t\tif(int(num) > ans and int(num) % 2 == 1):\n\t\t\tans = int(num)\n\t\tnum = ''\nprint(ans)";
			}
			if(i == 2){
				task = "Текстовом файл input.txt состоит не более чем из 1000000 символов.\nОпределите максимальное чётное число записанное в этом файле.";
				block.text = task;
				solution = "s = \"\"\nwith open(\"input.txt\") as f:\n\ts = f.read()\nans = -1\nnum = ''\nfor i in s:\n\tif(i.isdigit()):\n\t\tnum = num + i\n\telif(num != ''):\n\t\tif(int(num) > ans and int(num) % 2 == 0):\n\t\t\tans = int(num)\n\t\tnum = ''\nprint(ans)";
			}
			if(i == 3){
				task = "Текстовом файл input.txt состоит не более чем из 1000000 символов.\nОпределите минимальное нечётное число записанное в этом файле.";
				block.text = task;
				solution = "s = \"\"\nwith open(\"input.txt\") as f:\n\ts = f.read()\nans = 10**10\nnum = ''\nfor i in s:\n\tif(i.isdigit()):\n\t\tnum = num + i\n\telif(num != ''):\n\t\tif(int(num) < ans and int(num) % 2 == 1):\n\t\t\tans = int(num)\n\t\tnum = ''\nprint(ans)";
			}
			if(i == 4){
				task = "Текстовом файл input.txt состоит не более чем из 1000000 символов.\nОпределите минимальное чётное число записанное в этом файле.";
				block.text = task;
				solution = "s = \"\"\nwith open(\"input.txt\") as f:\n\ts = f.read()\nans = 10**10\nnum = ''\nfor i in s:\n\tif(i.isdigit()):\n\t\tnum = num + i\n\telif(num != ''):\n\t\tif(int(num) < ans and int(num) % 2 == 0):\n\t\t\tans = int(num)\n\t\tnum = ''\nprint(ans)";
			}
		}
		if(!Directory.Exists(desktop_path + @"\Task24")) Directory.CreateDirectory(desktop_path + @"\Task24");
		string path = desktop_path + @"\Task24\input.txt";
			using (StreamWriter sw = new StreamWriter(path, false, System.Text.Encoding.Default))
                {
                    sw.WriteLine(data);
                }
	}
    void Update()
    {
		if(len == -1){
			Process.Start(desktop_path + @"\Task24");
			len = 0;
		}
		else if(len == -2){
			File.Delete(desktop_path + @"\Task24\input.txt");
			File.Delete(desktop_path + @"\Task24\task.py");
			GenerateTask();
			check.text = "";
			remark.text = "";
		}
		else if(len == -3){
			len = 0;
			string ans;
			string path = desktop_path + @"\Task24\task.py";
			if (System.IO.File.Exists(desktop_path + @"\Task24\answer.py")){
				try {
					using (StreamWriter sw = new StreamWriter(path, false, System.Text.Encoding.Default))
						{
							sw.WriteLine(solution);
						}
					ProcessStartInfo p = new ProcessStartInfo(@"CMD.exe",@"/c cd /d " + desktop_path + @"\Task24" + " & answer.py");
					p.WindowStyle = ProcessWindowStyle.Hidden;
					p.RedirectStandardOutput = true;
					p.UseShellExecute = false;
					p.CreateNoWindow = true;
					Process cmdexe = Process.Start(p);
					System.Text.StringBuilder q = new System.Text.StringBuilder();
					while (!cmdexe.HasExited)
					{
						q.Append(cmdexe.StandardOutput.ReadLine());
					}
					ans = q.ToString();
					p =  new ProcessStartInfo(@"CMD.exe",@"/c cd /d " + desktop_path + @"\Task24" + " & task.py");
					p.WindowStyle = ProcessWindowStyle.Hidden;
					p.RedirectStandardOutput = true;
					p.UseShellExecute = false;
					p.CreateNoWindow = true;
					cmdexe = Process.Start(p);
					q = new System.Text.StringBuilder();
					while (!cmdexe.HasExited)
					{
						q.Append(cmdexe.StandardOutput.ReadLine());
					}
					string rans = q.ToString();
					check.text = "Ваш ответ: " + ans + "\nПравильный ответ: " + rans;
					remark.text = "Решение задачи на языке Python сохранено на рабочий стол под названием\n\"task.py\"";
				}
				catch (Exception e){
					check.text = "Ошибка выполнения программы!";
					UnityEngine.Debug.Log(e);
				}
			}
			else{
				check.text = "На рабочем столе нет файла answer.py!";
			}
		}
    }
}
