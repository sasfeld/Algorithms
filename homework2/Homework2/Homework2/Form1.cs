using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Homework2
{
    public partial class Form1 : Form
    {
        protected DocumentParser txtParser;

        public Form1()
        {
            InitializeComponent();

            this.txtParser = new TxtCorpusParser();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnLoadCorpus_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = this.createOpenFileDialog();

            this.triggerDialog(fileDialog);
        }

        protected OpenFileDialog createOpenFileDialog()
        {
            OpenFileDialog fileDialog = new OpenFileDialog();

            fileDialog.InitialDirectory = Directory.GetCurrentDirectory();
            fileDialog.Filter = "txt files (*.txt)|*.txt|All Files (*.*)|*.*";
            // set current filter to 'All files'
            fileDialog.FilterIndex = 2;
            // store last directoy when dialog is closed
            fileDialog.RestoreDirectory = true;

            return fileDialog;
        }

        protected void triggerDialog(OpenFileDialog dialog)
        {
            if (DialogResult.OK == dialog.ShowDialog())
            {
                String filePath = dialog.FileName;

                // start parsing and add document to document collection
                Document parsedDocument = this.txtParser.extractDocument(filePath);
                DocumentCollection.getInstance().addDocumentByFileName(filePath, parsedDocument);

                this.addInfo("Parsed " + filePath);
                // show first and last sentence
                this.printFirstAndLastSentence(parsedDocument);
                this.addInfo("");
            }
        }

        protected void printFirstAndLastSentence(Document parsedDocument)
        {
             String firstSentence = parsedDocument.getSentences()[0];
             String lastSentence = parsedDocument.getSentences()[parsedDocument.getSentences().Count - 1];

             this.addInfo("First sentence: " + firstSentence);
             this.addInfo("Last sentence: " + lastSentence);
        }

        protected void addInfo(String info)
        {
            this.txtInfo.AppendText(info + "\n");
        }

        private void btnTriggerPreprocesses_Click(object sender, EventArgs e)
        {
            // execute preprocesses chain
            DocumentCollection.getInstance().applyPreprocesses();

            // print results
            this.addInfo("Applied preprocesses");

            foreach (String processedDocument in DocumentCollection.getInstance().getAllDocuments().Keys)
            {
                this.addInfo("");
                this.addInfo("Processed document: " + processedDocument);

                Document doc = DocumentCollection.getInstance().getAllDocuments()[processedDocument];

                this.printFirstAndLastSentence(doc);
                this.addInfo("");
            }
        }
    }
}
