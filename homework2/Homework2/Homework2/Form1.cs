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

            fileDialog.InitialDirectory = Directory.GetCurrentDirectory() + "/../../data";
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

        protected void printFirstAndLastProcessedSentence(Document parsedDocument)
        {
            String firstSentence = parsedDocument.getProcessedSentences()[0];
            String lastSentence = parsedDocument.getProcessedSentences()[parsedDocument.getSentences().Count - 1];

            this.addInfo("First sentence: " + firstSentence);
            this.addInfo("Last sentence: " + lastSentence);
        }

        protected void addInfo(String info)
        {
            this.txtInfo.AppendText(info + "\n");
        }

        protected void addSearchTermOutput(String output)
        {
            this.txtSearchTermResults.AppendText(output + "\n");
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

                this.printFirstAndLastProcessedSentence(doc);
                this.addInfo("");
            }
        }

        protected long convertToLong(String input)
        {
            try
            {
                long outputInt = Convert.ToInt64(input);
                return outputInt;
            }
            catch (FormatException e)
            {
                addInfo("Please type in an valid integer!");
            }
            catch (OverflowException e)
            {
                addInfo("Please type in an valid integer!");
            }

            return 0;
        }

        private void btnGenerateNGrams_Click(object sender, EventArgs e)
        {
            this.generateNGrams(Document.NGrams.UNIGRAM);
            this.generateNGrams(Document.NGrams.BIGRAM);
            this.generateNGrams(Document.NGrams.TRIGRAM);

            this.addInfo("Created Unigram, Bigram and Trigram indexes.");
        }


        protected void generateNGrams(Document.NGrams nGramType)
        {
            DocumentCollection.getInstance().createIndex(nGramType);
        }

        private void btnSearchTerm_Click(object sender, EventArgs e)
        {
            String inputTerms = this.txtSearchTerm.Text;

            // trigger search
            Dictionary<String, long[]> results = DocumentCollection.getInstance().searchTerms(inputTerms);

            this.addSearchTermOutput("Finished search for terms: " + inputTerms);
            this.printSearchTermResults(inputTerms, results);

            // print empty line
            this.addSearchTermOutput("");
        }

        protected void printSearchTermResults(String inputTerms, Dictionary<String, long[]> results)
        {
            foreach (String docName in results.Keys)
            {
                this.addSearchTermOutput("## Results (sentences indices [Levenshtein similarity]) in document " + docName + " ##");

                String indicesString = "";
                foreach (long index in results[docName])
                {
                    if (0 == indicesString.Length % 40)
                    {
                        indicesString += "\n";
                    }

                    String sentence = this.getSentence(docName, index);

                    int levenshteinDistance = LevenshteinDistance.compute(inputTerms, sentence);
                    indicesString += index + " ["+ levenshteinDistance +"], ";
                }

                if ("" == indicesString)
                {
                    indicesString = "no results";
                }

                this.addSearchTermOutput(indicesString);

                this.addSearchTermOutput("##########################\n");
            }
        }

        protected String getSentence(String documentName, long sentenceIndex)
        {
            List<String> sentences = DocumentCollection.getInstance().getDocumentByFileName(documentName).getSentences();
            
            return sentences[(int) sentenceIndex];
        }

        private void btnSimilarSentences_Click(object sender, EventArgs e)
        {
            String inputSentence = txtSearchSentences.Text;
            long maxDistance = convertToLong(txtMaxDistance.Text);

            Dictionary<Document, SortedDictionary<int, HashSet<long>>> searchResults = DocumentCollection.getInstance().searchSimilarSentences(inputSentence, maxDistance);
            this.printSimilarSentencesResults(inputSentence, searchResults);
        }

        protected void printSimilarSentencesResults(String inputSentence, Dictionary<Document, SortedDictionary<int, HashSet<long>>> results)
        {
            foreach (Document doc in results.Keys)
            {
                SortedDictionary<int, HashSet<long>> similarSentences = results[doc];
                this.addSearchTermOutput("## Results (sentences indices [Levenshtein similarity]) in document " + doc.getName() + " ##");

                foreach (int levenshteinDistance in similarSentences.Keys)
                {
                    this.addSearchTermOutput("--- Levenshtein Distance = " + levenshteinDistance + " ---");

                    HashSet<long> sentenceIndices = similarSentences[levenshteinDistance];

                    String indicesString = "";
                    foreach (long index in sentenceIndices)
                    {
                        if (0 == indicesString.Length % 40)
                        {
                            indicesString += "\n";
                        }

                        indicesString += index + ", ";
                    }
                    this.addSearchTermOutput(indicesString);

                    this.addSearchTermOutput("----------------------------------");
                }


                this.addSearchTermOutput("##########################\n");
                this.addSearchTermOutput(" ");
            }
        }
    }
}
