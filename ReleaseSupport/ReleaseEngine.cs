using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Drawing;
using System.Diagnostics;

namespace ReleaseSupport
{
    public static class ReleaseEngine
    {
        public static void MakeRelease(object argListObject)
        {
            object[] argList = (object[])argListObject;

            MainForm parent = argList[0] as MainForm;
            string label = argList[1] as string;
            Customer customer = argList[2] as Customer;
            bool clean = (bool)argList[3];

            LetUserEnterNotes(customer, label);

            parent.AppendLogline(String.Format("==============================="), Color.Green);
            parent.AppendLogline(String.Format("|| Making release {0} for {1}", label, customer.Name), Color.Green);
            parent.AppendLogline(String.Format("==============================="), Color.Green);
            string basedir = customer.Home + @"\" + label;
            DirectoryInfo dirInfo = new DirectoryInfo(basedir);
            if (clean)
            {
                if (dirInfo.Exists)
                {
                    try
                    {
                        dirInfo.Delete(true);
                    }
                    catch (Exception exc)
                    {
                        parent.AppendLogline(String.Format("ERROR: Could not delete target dir {0}", basedir), Color.Red);
                        parent.AppendLogline(String.Format("{0}", exc.StackTrace), Color.Red);
                        return;
                    }
                }
                dirInfo.Create();
            }
            foreach (ReleaseComponent comp in customer.ReleaseComponents)
            {
                if (!comp.Included)
                    continue;

                parent.AppendLogline();
                parent.AppendLogline(String.Format("-------------------------------"), Color.Blue);
                parent.AppendLogline(String.Format("| Component {0}", comp.Name), Color.Blue);
                parent.AppendLogline(String.Format("-------------------------------"), Color.Blue);

                DirectoryInfo compSubDir = null;
                try
                {
                    compSubDir = dirInfo.CreateSubdirectory(comp.Target);
                }
                catch
                {
                    parent.AppendLogline(String.Format("ERROR: Could not delete target subdir {0}", comp.Target), Color.Red);
                    return;
                }
                string sourceDirName = comp.RootDir;
                DirectoryInfo srcDir = new DirectoryInfo(sourceDirName);
                comp.Filter = (comp.Filter == String.Empty) ? "*.*" : comp.Filter;
                string[] filters = comp.Filter.Split('|');
                foreach (string filter in filters)
                {
                    FileInfo[] sourceFiles = srcDir.GetFiles(filter, (comp.Deep) ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly);
                    foreach (FileInfo sourceFile in sourceFiles)
                    {
                        string targetFileName = compSubDir.FullName;
                        targetFileName += sourceFile.FullName.Replace(srcDir.FullName, "");
                        parent.AppendLogtext(targetFileName);
                        try
                        {
                            FileInfo targetFile = new FileInfo(targetFileName);
                            if (!clean && targetFile.Exists)
                                targetFile.Delete();
                            else if (!targetFile.Directory.Exists)
                                targetFile.Directory.Create();
                            sourceFile.CopyTo(targetFileName);
                            parent.AppendLogline(" [OK]", Color.LightGray);
                        }
                        catch (Exception exc)
                        {
                            parent.AppendLogline(String.Format("ERROR: moving file {0}:", sourceFile.FullName), Color.Red);
                            parent.AppendLogline(exc.Message, Color.Red);
                            parent.AppendLogline(exc.StackTrace, Color.Red);
                            return;
                        }

                    }
                }
            }
        }

        private static void LetUserEnterNotes(Customer customer, string label)
        {
            FileInfo releaseNotes = new FileInfo(Path.Combine(customer.Home, customer.Notes));
            if (!releaseNotes.Exists)
                return;
            using (var sw = new StreamWriter(releaseNotes.FullName, true))
            {
                sw.WriteLine();
                sw.WriteLine("Release '{0}' created on {1:dd/MM/yyyy HH:mm:ss}", label, DateTime.Now);
                sw.WriteLine("----------------------------------------------------");
                sw.Close();
            }
            Process myProcess = new Process();
            myProcess.StartInfo.FileName = "notepad.exe"; //not the full application path
            myProcess.StartInfo.Arguments = releaseNotes.FullName;
            myProcess.Start();
            myProcess.WaitForExit();
        }
    }
}
