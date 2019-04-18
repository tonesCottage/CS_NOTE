using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestReflect.Common
{
    public class ReadFile
    {
        //根据表格字段信息，生成创建表所需要的（filed type）
        public string readfile(string loadPath)
        {
            StreamReader sr = new StreamReader(@loadPath, Encoding.Default);
            String sLine = "";
            string strl = "";
            StringBuilder sb = new StringBuilder();
            while (sLine != null)
            {
                sLine = sr.ReadLine();
                if (!String.IsNullOrEmpty(sLine))
                {
                    string[] str = sLine.Split('=');
                    //建表语句
                    //strl = str[0] + " "+str[2]+",";
                    //所有字段
                    //strl = str[0] + ",";
                    //update语句
                    //strl = str[0] + "=:" + str[0] + ",";
                    strl = str[1];
                    //调用构造方法时，使用
                    //strl = "wpf." + str[5] + ",";
                    sb.Append(strl.Trim());
                }
            }
            sr.Close();
            sLine = sb.ToString();
            sLine = sLine.Substring(0, sLine.Length - 1);
            return sLine;
        }
        //批量读取
        public void Mulireadfile()
        {
            List<string> list = filePath();
            foreach (string item in list)
            {
                readfileForModel(item);
            }
        }
        //获取数据类型信息
        public string getDatatype(string[] str)
        {
            int i= 3;
            while (string.IsNullOrEmpty(str[i]))
            {
                i++;
            }
            return str[i];
        }
        //根据表格字段信息，生成model字段
        public string readfileForModel(string name)
        {
            string filename = name.Split('\\')[7].Split('.')[0];
            string tableName="";
            StreamReader sr = new StreamReader(name, Encoding.Default);
            String sLine = "";
            string strl = "";
            string ConstructionString = "";
            int i = 0;
            //string modelName = "";
            StringBuilder sb = new StringBuilder();
            //构造函数字符串
            StringBuilder cs1 = new StringBuilder();
            StringBuilder cs2 = new StringBuilder();
            StringBuilder cs3 = new StringBuilder();
            StringBuilder cs4 = new StringBuilder();
            sb.Append("using System;\r\nusing System.Collections.Generic;\r\nusing System.Linq;\r\nusing System.Text;\r\n\r\nnamespace DataModels.Model\r\n{\r\n\r\n\0\0\0\0public class " + filename + ":Entity\r\n\0\0\0\0{\r\n");
            while (sLine != null)
            {
                    sLine = sr.ReadLine();
                    //终止条件
                    if (sLine==")")
                    {
                        break;
                    }
                    if (!String.IsNullOrEmpty(sLine))
                    {
                        //开始字段
                        if (i>2)
                        {
                        string[] str = SplitString(sLine);
                        sLine.Trim();

                        //字段类型，以及字段名
                        string fieldName = "", type = "";
                        switch (ConfigurationManager.AppSettings["modeltype"])
                        {
                            case "sql":
                                fieldName = str[2];
                                type = judgeType(getDatatype(str));
                                //type=judgeType(sLine.Substring(14, sLine.Length - 14).ToUpper());
                                break;
                            default:
                                break;
                        }

                        cs1.Append(type + " " + fieldName + ",");
                        cs2.Append("\0\0\0\0\0\0\0\0\0\0\0\0this." + fieldName + "=" + fieldName + ";\r\n");
                        cs3.Append(fieldName + ","); cs4.Append(":" + fieldName + ",");
                        strl = "\r\n\0\0\0\0\0\0\0\0public " + type + " " + fieldName + "\r\n\0\0\0\0\0\0\0\0{\r\n\0\0\0\0\0\0\0\0\0\0\0\0set;\r\n\0\0\0\0\0\0\0\0\0\0\0\0get;\r\n\0\0\0\0\0\0\0\0}\r\n";
                        sb.Append(strl);
                        }else{
                            if (i == 1) {
                                tableName = SplitString(sLine)[2];
                            }
                        }
                        i++;
                    }
                
            }
            string cs1String = cs1.ToString();
            ConstructionString = "\0\0\0\0\0\0\0\0public " + filename + "(" + cs1String.Substring(0, cs1String.Length - 1) + ")\r\n\0\0\0\0\0\0\0\0{\r\n" + cs2.ToString() + "\0\0\0\0\0\0\0\0}\r\n\0\0\0\0\0\0\0\0public "+filename+"(){}\r\n";

            sb.Append(ConstructionString);

            //sql语句
            string insertSql = "insert into " + tableName + "(" + cs3.ToString().TrimEnd(',') + ") VALUES(" + cs4.ToString().TrimEnd(',') + ")";
            string updateSql="update "+tableName+"";
            string delSql="delete "+tableName+"";
            string isExistSql="select * from "+tableName+" where ";
            string querySql = "select * from "+tableName;

            string sqlkey = getSql("Key","");
            string sqlTable = getSql("Table()");
            string sqlInsert = getSql("InsertSql", insertSql);
            string sqlUpdate = getSql("UpdateSql", updateSql);
            string sqlDel = getSql("DelSql", delSql);
            string sqlIsExist = getSql("IsExistSql", isExistSql);
            string sqlQuery = getSql("QuerySql", querySql); 


            sr.Close();
            sb.Append(sqlkey + sqlTable + sqlInsert + sqlUpdate + sqlDel + sqlIsExist + sqlQuery);
            sb.Append("\0\0\0\0\0}\r\n}");
            sLine = sb.ToString();

            // 创建文件
            FileStream fs = new FileStream("C:\\Users\\Administrator\\Desktop\\项目组\\比亚迪\\实体类\\" + filename + ".cs", FileMode.OpenOrCreate, FileAccess.ReadWrite); //可以指定盘符，也可以指定任意文件名，还可以为word等文件
            StreamWriter sw = new StreamWriter(fs); // 创建写入流
            sw.WriteLine(sLine); // 写入Hello World
            sw.Close(); //关闭文件
            return sLine;
        }

        //根据cs 得到查询语句，生成构造函数内容
        public string readModelCsForSql(string loadPath)
        {
            StreamReader sr = new StreamReader(@loadPath, Encoding.Default);
            String sLine = "";
            string className = "";
            StringBuilder cs1 = new StringBuilder();
            StringBuilder cs2 = new StringBuilder();
            StringBuilder cs3 = new StringBuilder();
            StringBuilder cs4 = new StringBuilder();
            bool judgeClass = true;
            while (sLine != null)
            {
                sLine = sr.ReadLine();
                if (!String.IsNullOrEmpty(sLine))
                {
                    string[] str = sLine.Split(' ');
                    if (judgeClass)
                    {
                        //筛选类名
                        if (sLine.Contains("class"))
                        {
                            judgeClass = false;
                            className = str[6];
                        }
                    }
                    //类名判断完成，判断字段
                    else
                    {
                        if (sLine.Contains("public") || sLine.Contains("private"))
                        {
                            string type = str[9];
                            string fieldName = str[10];

                            cs1.Append(fieldName + ",");
                            cs2.Append(":" + fieldName + ",");
                            cs3.Append(type + " " + fieldName + ",");
                            cs4.Append("        this." + fieldName + "=" + fieldName + ";\r\n");
                        }
                    }
                    if (sLine.Contains("endregion"))
                    {
                        break;
                    }
                }
            }
            string cs1Tostring = cs1.ToString();
            string cs2Tostring = cs2.ToString();
            string cs3Tostring = cs3.ToString();

            sLine = "insert into " + className + " (" + cs1Tostring.Substring(0, cs1Tostring.Length - 1) + ") VALUES(" + cs2Tostring.Substring(0, cs2Tostring.Length - 1) + ")";

            className = "      public " + className + "(" + cs3Tostring.Substring(0, cs3Tostring.Length - 1) + ")\r\n      {\r\n" + cs4.ToString() + "      }\r\n";
            FileStream fs = new FileStream(ConfigurationManager.AppSettings["filePath"]+"\\test.cs", FileMode.OpenOrCreate, FileAccess.ReadWrite); //可以指定盘符，也可以指定任意文件名，还可以为word等文件
            StreamWriter sw = new StreamWriter(fs); // 创建写入流
            sw.WriteLine(className); // 写入Hello World
            sw.Close(); //关闭文件

            return sLine;
        }
        public string[] SplitString(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return null;
            }
            else
            {
                string[] strs = str.Split('\t');
                if (strs.Count() == 1)
                {
                    strs = str.Split(' ');
                }
                return strs;
            }
            
        }
        public string getSql(string sqlName,string SqlSentence)
        {
            return "\0\0\0\0\0\0\0\0public override string " + sqlName + "\r\n\0\0\0\0\0\0\0\0{\r\n\0\0\0\0\0\0\0\0\0\0\0\0get\r\n\0\0\0\0\0\0\0\0\0\0\0\0{\r\n\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0return @\"" + SqlSentence + "\";\r\n\0\0\0\0\0\0\0\0\0\0\0\0}\r\n\0\0\0\0\0\0\0\0}\r\n";
        }
        public string getSql(string sqlName)
        {
            return "\0\0\0\0\0\0\0\0public override string " + sqlName + "\r\n\0\0\0\0\0\0\0\0{\r\n\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0return @\"\";\r\n\0\0\0\0\0\0\0\0}\r\n";
        }
        public string judgeType(string dataType)
        {
            string SType = "";
            dataType = dataType.Trim(',').Trim(); 
            if (dataType.Contains("CHAR"))
            {
                SType = "string";
            }
            else
            {
                if (dataType.Contains("INT"))
                {
                    SType = "int";
                }
                else
                {
                    if (dataType.Contains("TIME") || dataType.Contains("DATE"))
                    {
                        SType = "DateTime";
                    }
                    else
                    {
                        if (dataType.Contains("NUMBER"))
                        {
                            SType = "Double";
                        }
                        else
                        {
                            switch (dataType)
                            {
                                case "CLOB":
                                    SType = "string";
                                    break;
                                case "BLOB":
                                    SType = "byte[]";
                                    break;
                                case "BFILE":
                                    SType = "byte[]";
                                    break;
                                case "TEXT":
                                    SType = "string";
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                }
            }
            return SType;
        }
        
        public string updateSql(string sql)
        {
            //"ID="+"'"+b.ID+"',"
            string[] strs = sql.Split(',');
            StringBuilder sb = new StringBuilder();
            foreach (string item in strs)
            {
                sb.Append("',"+item+"='"+"+b."+item+"+");
            }
            return sb.ToString();
        }
        public string TextFilePath()
        {
            string loadPath = ConfigurationManager.AppSettings["filePath"];
            string filename = "PPAP_EI_TASKSTART_SUBMIT.txt";
            loadPath += filename;
            return @loadPath;
        }
        public string CsFilePath()
        {
            string loadPath = ConfigurationManager.AppSettings["filePath"];
            string filename = "BO_ACT_JZHYFCS.cs";
            loadPath += filename;
            return @loadPath;
        }
        public List<string> filePath()
        {
            DirectoryInfo folder = new DirectoryInfo(ConfigurationManager.AppSettings["filePath"].ToString());
            List<string> list = new List<string>();
            foreach (FileInfo file in folder.GetFiles("*.txt"))
            {
                list.Add(file.FullName);
            }
            return list;
        }
    }
}
