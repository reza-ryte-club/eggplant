using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;
using System.IO;
using System.Diagnostics;
using EggPlantGUI;
using EggplantCore;
using Parser;
using AvalonDock;

namespace EggplantGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string seq;
        public string fileName ;

        public MainWindow()
        {
            //InitializeComponent();
            this.DataContext = this;
        }

        private void OpenFile_Click(object sender, RoutedEventArgs e)
        {
            var doc = new Document();
            int j;
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "FASTA Files (*.fasta)|*.fasta|Sequence Files (*.seq) |*.seq| Protein Data Bank (*.pdb)|*.pdb";

            if (dlg.ShowDialog().GetValueOrDefault())
            {
                fileName = String.Copy(dlg.FileName);
                using (StreamReader sr = new StreamReader(dlg.FileName))
                {
                    bool flag = true;
                    int i = dockingManager.Documents.Count;
                    for (j = 0; j < i; j++)
                    {
                        if (dlg.FileName == dockingManager.Documents[j].Tag.ToString())
                        {
                            flag = false;
                            break;
                        }
                    }
                    if (flag == true)
                    {
                        doc = new Document() { Title = System.IO.Path.GetFileName(dlg.FileName) };
                        doc.Show(dockingManager);
                        doc.TextContent = sr.ReadToEnd();
                        doc.Tag = dlg.FileName.ToString();
                        doc.Activate();
                    }
                    else
                    {
                        dockingManager.ActiveDocument = dockingManager.Documents[j];
                    }

                }
            }
        }

        private void New_click(object sender, RoutedEventArgs e)
        {
            string title = "Sequence 0";
            int i = 1;

            while (dockingManager.Documents.Any(d => d.Title == title))
            {
                title = "Sequence " + i.ToString();
                i++;
            }
            
            var doc = new Document() { Title = title };
            doc.Show(dockingManager);
            doc.Tag = "";
            doc.Activate();
        }

        private void SaveFile_Click(object sender, System.EventArgs e)
        {
            savedocument();
        }
        private void getCurrentSequence(){

            // string sequence;
            Fasta fs = new Fasta();
            seq = fs.fastaReader(this.fileName);
        }

        private void SaveAsFile_Click(object sender, System.EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
          //  saveFileDialog1.Filter = "FASTA Files (*.fasta)|*.fasta|Sequence Files (*.seq) |*.seq| Protein Data Bank (*.pdb)|*.pdb";

            saveFileDialog1.Filter = "FASTA Files (*.fasta)|*.fasta";
            saveFileDialog1.Title = "Save a Sequence File";
            saveFileDialog1.ShowDialog();

            if (saveFileDialog1.FileName != "")
            {
                string url = saveFileDialog1.FileName;
                StreamWriter file = new StreamWriter(@url);

                var docfile = dockingManager.ActiveContent as Document;
                string test = docfile.TextContent.ToString();

                file.Write(test);
                file.Flush();
                file.Close();
                dockingManager.ActiveContent.Title = saveFileDialog1.SafeFileName.ToString();
                dockingManager.ActiveDocument.Tag = saveFileDialog1.FileName.ToString();
            }
        }

        private void Close_click(object sender, RoutedEventArgs e)
        {
            closedocument();
            dockingManager.ActiveDocument.Close();
        }
        private void QuitFile_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void AboutHelp_Click(object sender, System.EventArgs e)
        {

            AboutDialog aboutdlg = new AboutDialog();
            aboutdlg.ShowDialog();
        }

      

            private void AbsorbancePrimary_Click(object sender, RoutedEventArgs e)
        {

            this.getCurrentSequence();

            double[] absorbance = new double[2];
            Array.Copy(Primary.absorbancePrimary(seq), absorbance, 2);

        //    textOutBox.FontSize = 12;

            textOutBox.Text = "Absorbance :  " + absorbance[0] + " and " + absorbance[1];
           
  
        }

            private void AliphaticIndexPrimary_Click(object sender, RoutedEventArgs e)
            {

                this.getCurrentSequence();

                textOutBox.Text = "Aliphatic Index : " + Primary.aliphaticIndex(seq);
            }


            private void TranslationPrimary_Click(object sender, RoutedEventArgs e)
            {

                this.getCurrentSequence();


                textOutBox.Text = Primary.translate(seq);



            }

            private void TranscriptionPrimary_Click(object sender, RoutedEventArgs e)
            {

                this.getCurrentSequence();


                textOutBox.Text = Primary.transcription(seq);
            }

        private void TotalNumberOfAtomsPrimary_Click(object sender, RoutedEventArgs e)
        {

            this.getCurrentSequence();
            int c = Primary.carbonCounter(seq);
            int h = Primary.hydrogenCounter(seq);
            int n = Primary.nitrogenCounter(seq);
            int o = Primary.oxygenCounter(seq);
            int s = Primary.sulfurCounter(seq);
            string chemicalFormula = null;
            if (c != 0) chemicalFormula = "Carbon        C     " + c;
            if (h != 0) chemicalFormula = chemicalFormula + "\nHydrogen     H     " + h;
            if (n != 0) chemicalFormula = chemicalFormula + "\nNitrogen      N     " + n;
            if (o != 0) chemicalFormula = chemicalFormula + "\nOxygen        O     " + o;
            if (s != 0) chemicalFormula = chemicalFormula + "\nSulpher       S     " + s;


            if (seq.Contains("B") || seq.Contains("Z") || seq.Contains("X"))
                textOutBox.Text = "As there is at least one ambiguous position (B,Z or X) in the sequence considered,"
                                    + "\nthe atomic composition cannot be computed.";
            else
                textOutBox.Text = chemicalFormula;


        }


        private void MolecularWeightPrimary_Click(object sender, RoutedEventArgs e)
        {

            this.getCurrentSequence();


            textOutBox.Text = "Molecular Weight : " + Primary.getMolecularWeight(seq);


        }

        private void ChemicalFormulaPrimary_Click(object sender, RoutedEventArgs e)
        {

            this.getCurrentSequence();
            int c = Primary.carbonCounter(seq);
            int h = Primary.hydrogenCounter(seq);
            int n = Primary.nitrogenCounter(seq);
            int o = Primary.oxygenCounter(seq);
            int s = Primary.sulfurCounter(seq);
            string chemicalFormula = null;
            if (c != 0) chemicalFormula = " C" + c;
            if (h != 0) chemicalFormula = chemicalFormula + " H" + h;
            if (n != 0) chemicalFormula = chemicalFormula + " N" + n;
            if (o != 0) chemicalFormula = chemicalFormula + " O" + o;
            if (s != 0) chemicalFormula = chemicalFormula + " S" + s;
            //textOutBox.FontSize = 30;
            textOutBox.Text = "Chemical Formula : " + chemicalFormula;


        }

        private void completeAnalysisPrimary_Click(object sender, RoutedEventArgs e)
        {


            this.getCurrentSequence();
//            int noOfAminoAcids = seqLength;
            double molecularWeight = Primary.getMolecularWeight(seq);
            int negativeResidues = Primary.negativeAminoAcidCounter(seq);
            string acidComposition = Primary.acidComposition(seq);
            int negativeCounter = Primary.negativeAminoAcidCounter(seq);
            int positiveCounter = Primary.positiveAminoAcidCounter(seq);
            int[] eCoefficient = new int[2];
            string extinctionText;
            double aliphaticIndex = Primary.aliphaticIndex(seq);
            int carbonCounter = Primary.carbonCounter(seq);
            double GRAVY = Primary.gravy(seq);
            Array.Copy(Primary.extinctionCoefficient(seq), eCoefficient, 2);

            if (eCoefficient[0] != 0 || eCoefficient[1] != 0)
                extinctionText = "Extinction coefficients are in units of 1/M 1/cm, at 280 nm measured in water." +
                    "\nExtinction Coefficient :  " + eCoefficient[0] + " and " + eCoefficient[1];
            else
                extinctionText = "As there are no Trp, Tyr or Cys in the region considered, your protein should not be visible by UV spectrophotometry.";


            textOutBox.Text = "Complete Analysis: \n\n" + "Number of amino acids: " +
                                seq.Length + "\nMolecular weight: " + molecularWeight + "\n\n" + acidComposition
                                + "\n\nTotal number of negatively charged residues (Asp + Glu): " + negativeCounter
                                + "\n\nTotal number of positively charged residues (Arg + Lys): " + positiveCounter
                                + "\n\n" + extinctionText
                                + "Halflife : \n\n" + "The N-terminal of the sequence considered is " + seq[0] + "\n\n" + Primary.halfLifePrimary(seq)
                                + "\n\nAliphatic Index  " + aliphaticIndex
                                + "\n\nGrand average of hydropathicity (GRAVY): " + GRAVY;
                                





        }
        private void gravyPrimary_Click(object sender, RoutedEventArgs e)
        {

            this.getCurrentSequence();

            textOutBox.Text = "Grand Average of Hydropathiticity (GRAVY) :\n\n" + Primary.gravy(seq);
        }
       
        
        
        
        private void halfLifePrimary_Click(object sender, RoutedEventArgs e)
        {

            this.getCurrentSequence();

            textOutBox.Text = "Halflife : \n\n" + "The N-terminal of the sequence considered is " + seq[0] + "\n\n" + Primary.halfLifePrimary(seq);
        }

        
        
        
        
        private void ExtinctionCoefficientPrimary_Click(object sender, RoutedEventArgs e)
        {

            this.getCurrentSequence();
            int[] eCoefficient = new int[2];
            Array.Copy(Primary.extinctionCoefficient(seq), eCoefficient, 2);
            //            string minus1 = "-1";
            //          minus1.

            //  textOutBox.FontSize = 12;

            if (eCoefficient[0] != 0 || eCoefficient[1] != 0)
                textOutBox.Text = "Extinction coefficients are in units of 1/M 1/cm, at 280 nm measured in water." +
                    "\nExtinction Coefficient :  " + eCoefficient[0] + " and " + eCoefficient[1];
            else
                textOutBox.Text = "As there are no Trp, Tyr or Cys in the region considered, your protein should not be visible by UV spectrophotometry.";

        }



             private void AcidCompositionPrimary_Click(object sender, RoutedEventArgs e)
        {

            this.getCurrentSequence();
            textOutBox.Text = Primary.acidComposition(seq);
                //"Amoino Acid Composition:\n \n"+ "G"+"\nA"+"\nP"+"\nV"+
                //"\nL" + "\nI" + "\nM" + "\nF" + "\nY" + "\nW" + "\nS" + "\nT" + "\nC" + "\nN" + "\nQ" + "\nK" + "\nH" + "\nR" + "\nD" + "\nE";

        }


             private void SummarySecondary_Click(object sender, RoutedEventArgs e)
             {

                 try
                 {
                     File.Delete("result.txt");
                     ProcessStartInfo processStartInfo = new ProcessStartInfo("cmd.exe");
                     processStartInfo.RedirectStandardInput = true;
                     processStartInfo.RedirectStandardOutput = true;
                     processStartInfo.UseShellExecute = false;
                     processStartInfo.CreateNoWindow = true;

                     Process gor4 = Process.Start(processStartInfo);
                     gor4.StartInfo.FileName = "gorIV.exe";
                     gor4.StartInfo.Arguments = "Test.fasta";

                     gor4.Start();
                     gor4.WaitForExit();
                     string result = File.ReadAllText("result.txt");
                     int len = result.Length - 135;

                     string summaryResult = result.Substring(len, 135);
                     textOutBox.Text = summaryResult;
                 }
                 catch (Exception ex) { textOutBox.Text = ex.Message; }
             }



             private void VerboseSecondary_Click(object sender, RoutedEventArgs e)
             {







                 try
                 {
                     File.Delete("result.txt");
                     ProcessStartInfo processStartInfo = new ProcessStartInfo("cmd.exe");
                     processStartInfo.RedirectStandardInput = true;
                     processStartInfo.RedirectStandardOutput = true;
                     processStartInfo.UseShellExecute = false;
                     processStartInfo.CreateNoWindow = true;

                     Process gor4 = Process.Start(processStartInfo);
                     gor4.StartInfo.FileName = "gorIV.exe";
                     gor4.StartInfo.Arguments = "Test.fasta";

                     gor4.Start();
                     gor4.WaitForExit();
                     getresult();




                 }
                 catch (Exception ex)
                 {
                     textOutBox.Text = ex.Message;
                 }



             }
             private void getresult()
             {
                 string result = File.ReadAllText("result.txt");
                 textOutBox.Text = result;

             }


        private void Window_GotFocus(object sender, RoutedEventArgs e)
        {
            if (dockingManager.Documents.Count == 0)
            {
                invisible();
            }
            else
            {
                visible();
            }
        }
        public void invisible()
        {
            savemenu.IsEnabled = false;
            saveasmenu.IsEnabled = false;
            closemenu.IsEnabled = false;
        }
        public void visible()
        {
            savemenu.IsEnabled = true;
            saveasmenu.IsEnabled = true;
            closemenu.IsEnabled = true;
        }

        private void dockingManager_DocumentClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            closedocument();
        }
        public void closedocument()
        {

            if (dockingManager.ActiveDocument.Tag.ToString() != "")
            {
                StreamReader readoldfile = new StreamReader(@dockingManager.ActiveDocument.Tag.ToString());
                string oldtext = readoldfile.ReadToEnd();
                readoldfile.Close();
                readoldfile = null;
                var newdocfile = dockingManager.ActiveContent as Document;
                string newfile = newdocfile.TextContent.ToString();
                if (oldtext != newfile)
                {
                    if (MessageBox.Show("Would you like to save the changes ?", "EggPlant", MessageBoxButton.YesNo,MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        string url = dockingManager.ActiveDocument.Tag.ToString();
                        StreamWriter file = new StreamWriter(@url);

                        var docfile = dockingManager.ActiveContent as Document;
                        string test = docfile.TextContent.ToString();

                        file.Write(test);
                        file.Flush();
                        file.Close();
                        file = null;
                    }
                }
            }
            else
            {
                
                if (MessageBox.Show("Would you like to save the changes ?", "EggPlant", MessageBoxButton.YesNo,MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                    saveFileDialog1.Filter = "FASTA Files (*.fasta)|*.fasta|Sequence Files (*.seq) |*.seq| Protein Data Bank (*.pdb)|*.pdb";
                    saveFileDialog1.Title = "Save a Sequence File";
                    saveFileDialog1.ShowDialog();

                    if (saveFileDialog1.FileName != "")
                    {
                        string url = saveFileDialog1.FileName;
                        StreamWriter file = new StreamWriter(@url);

                        var docfile = dockingManager.ActiveContent as Document;
                        string test = docfile.TextContent.ToString();

                        file.Write(test);
                        file.Flush();
                        file.Close();
                    }
                }
            }
        }
        public void savedocument()
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "FASTA Files (*.fasta)|*.fasta|Sequence Files (*.seq) |*.seq| Protein Data Bank (*.pdb)|*.pdb";
            saveFileDialog1.Title = "Save a Sequence File";
            string activetag = dockingManager.ActiveDocument.Tag.ToString();
            if (activetag != "")
            {
                if (!File.Exists(@activetag))
                {
                    saveFileDialog1.ShowDialog();
                    if (saveFileDialog1.FileName != "")
                    {
                        string url = saveFileDialog1.FileName;
                        StreamWriter file = new StreamWriter(@url);

                        var docfile = dockingManager.ActiveContent as Document;
                        string test = docfile.TextContent.ToString();

                        file.Write(test);
                        file.Flush();
                        file.Close();
                        dockingManager.ActiveContent.Title = saveFileDialog1.SafeFileName.ToString();
                        dockingManager.ActiveDocument.Tag = saveFileDialog1.FileName.ToString();
                    }
                }
                else
                {
                    string dockname1 = dockingManager.ActiveDocument.Title;
                    string dockname2 = "" ;
                    int index = dockname1.Length - 1;
                    if (dockname1[index] == '*')
                    {
                        char[] array = new char[index];
                        for (int j = 0; j < index; j++)
                        {
                            array[j] = dockname1[j];
                        }
                        dockname2 = new string(array);
                        //MessageBox.Show(dockname2.Length.ToString());
                    }
                    

                    StreamWriter file = new StreamWriter(@activetag);

                    var docfile = dockingManager.ActiveContent as Document;
                    string test = docfile.TextContent.ToString();

                    file.Write(test);
                    file.Flush();
                    file.Close();
                    dockingManager.ActiveContent.Title = dockname2;
                    dockingManager.ActiveDocument.Tag = activetag;
                }
            }
            else
            {
                saveFileDialog1.ShowDialog();
                if (saveFileDialog1.FileName != "")
                {
                    string url = saveFileDialog1.FileName;
                    StreamWriter file = new StreamWriter(@url);

                    var docfile = dockingManager.ActiveContent as Document;
                    string test = docfile.TextContent.ToString();

                    file.Write(test);
                    file.Flush();
                    file.Close();
                    dockingManager.ActiveContent.Title = saveFileDialog1.SafeFileName.ToString();
                    dockingManager.ActiveDocument.Tag = saveFileDialog1.FileName.ToString();
                }
            }
            
        }

        private void dockingManager_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false) == true)
            {
                e.Effects = DragDropEffects.Copy;
            }  
        }

        private void dockingManager_Drop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string n in files)
            {
                string format = System.IO.Path.GetExtension(@n).ToString();
                if (format == ".fasta" || format == ".seq" || format == ".pdb")
                {
                    StreamReader sr = new StreamReader(@n);
                    var doc = new Document() { Title = System.IO.Path.GetFileName(@n).ToString() };
                    doc.Show(dockingManager);
                    doc.TextContent = sr.ReadToEnd();
                    doc.Tag = n;
                    doc.Activate();
                    sr.Close();
                    sr = null;
                }
                else
                {
                    MessageBox.Show("Unsupported File Format.Only fasta files are supported.", "EggPlant");
                }
            }
        }

        private void dockingManager_KeyDown(object sender, KeyEventArgs e)
        {
            string title = dockingManager.ActiveContent.Title;
            int index = title.Length;
            char star = title[index - 1];
            if (star != '*')
            {
                title = title + "*";
                dockingManager.ActiveContent.Title = title;
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

    }
}
