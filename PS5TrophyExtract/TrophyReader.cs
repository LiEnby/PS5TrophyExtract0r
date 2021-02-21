using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PS5TrophyExtract
{
    public partial class TrophyReader : Form
    {
        public TrophyReader()
        {
            InitializeComponent();
        }

        public List<TableOfContents> TOC = new List<TableOfContents>();
        public class TableOfContents
        {
            public TableOfContents(int offset, int length, string filename)
            {
                Offset = offset;
                Length = length;
                Filename = filename;
            }

            public int Offset;
            public int Length;
            public string Filename;
            
        }

        private Stream data;

        private string readCStr()
        {
            string str = "";
            while(true)
            {
                byte readByte = (byte)data.ReadByte();
                if (readByte != 0)
                    str += (char)readByte;
                else
                    break;
            }
            return str;
        }
        private int readInt32()
        {
            byte[] intBytes = new byte[4];
            data.Read(intBytes, 0x00, intBytes.Length);
            return BitConverter.ToInt32(intBytes, 0);
        }
        private int readInt32BE()
        {
            byte[] intBytes = new byte[4];
            data.Read(intBytes, 0x00, intBytes.Length);
            intBytes = intBytes.Reverse().ToArray();
            return BitConverter.ToInt32(intBytes, 0);
        }
        private void readToc(string filename)
        {
            if (data != null)
                data.Dispose();

            FileStream fs = File.OpenRead(filename);
            data = fs;

            fs.Seek(0x13, SeekOrigin.Begin);
            int totalEntries = readInt32();
            int tocLocation = readInt32();

            fs.Seek(tocLocation, SeekOrigin.Begin);
            fs.Seek(0x10, SeekOrigin.Current);

            // Read toc
            for (int i = 0; i < totalEntries; i++)
            {
                fs.Seek(0x10, SeekOrigin.Current);
                string fileName = readCStr();
                fs.Seek(0x23 - fileName.Length, SeekOrigin.Current);
                int fileLocation = readInt32BE();
                fs.Seek(0x4, SeekOrigin.Current);
                int fileEnd = readInt32BE();

                TableOfContents toc = new TableOfContents(fileLocation, fileEnd, fileName);
                TOC.Add(toc);
            }

        }

        private byte[] readFile(TableOfContents tocEntry)
        {
            byte[] fileData = new byte[tocEntry.Length];
            data.Seek(tocEntry.Offset, SeekOrigin.Begin);
            data.Read(fileData, 0x00, tocEntry.Length);
            return fileData;
        }

        private void populateList()
        {
            trophyDataFiles.Items.Clear();

            foreach(TableOfContents contents in TOC)
            {
                trophyDataFiles.Items.Add(contents.Filename);
            }

            extractFile.Enabled = false;
            extractAll.Enabled = true;
        }


        private void openTrophys_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Trophy Set Files (*.ucp)|*.ucp";
            DialogResult res = fileDialog.ShowDialog();
            if(res == DialogResult.OK)
            {
                string filePath = fileDialog.FileName;
                readToc(filePath);
                populateList();
                previewBox.BackgroundImage = null;
            }

        }

        private void trophyDataFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                previewBox.BackgroundImage = Bitmap.FromStream(new MemoryStream(readFile(TOC[trophyDataFiles.SelectedIndex])));
            }
            catch (Exception) {
                previewBox.BackgroundImage = previewBox.ErrorImage;
            };

            if (trophyDataFiles.SelectedIndex >= 0 && trophyDataFiles.SelectedIndex < TOC.Count)
            {
                extractFile.Enabled = true;
            }    

        }

        private void extractFile_Click(object sender, EventArgs e)
        {
            if (!(trophyDataFiles.SelectedIndex >= 0 && trophyDataFiles.SelectedIndex < TOC.Count))
                return;
                
            TableOfContents file = TOC[trophyDataFiles.SelectedIndex];

            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.FileName = file.Filename;
            fileDialog.Title = "Save file";
            DialogResult res = fileDialog.ShowDialog();
            if(res == DialogResult.OK)
            {
                File.WriteAllBytes(fileDialog.FileName, readFile(file));
                MessageBox.Show("Saved file to " + fileDialog.FileName, "Saved!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void extractAll_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDialog = new FolderBrowserDialog();
            folderDialog.Description = "Output folder";
            DialogResult res = folderDialog.ShowDialog();
            if(res == DialogResult.OK)
            {
                foreach(TableOfContents content in TOC)
                {
                    string newFile = Path.Combine(folderDialog.SelectedPath, content.Filename);
                    File.WriteAllBytes(newFile, readFile(content));
                }
                MessageBox.Show("Saved all files to " + folderDialog.SelectedPath, "Saved!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
