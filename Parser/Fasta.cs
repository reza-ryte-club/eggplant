using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Parser;

namespace Parser
{
    public class Fasta
    {
        

        public string fastaReader(string fileName)
        {
            using (StreamReader sr = new StreamReader(fileName))
            {
                string tempSequence;
                tempSequence = sr.ReadToEnd();

                char[] tempSequenceChar = tempSequence.ToCharArray();
                int lineCounter, sequenceLength = 0;

                lineCounter = 0;
                int i, j;

                for (i = 0, j = 0; i < tempSequenceChar.Length; i++)
                {
                    if (tempSequenceChar[i] == '\n') lineCounter++;

                    if (lineCounter >= 1 && (tempSequenceChar[i] == 'G' || tempSequenceChar[i] == 'A' || tempSequenceChar[i] == 'P' ||
                                             tempSequenceChar[i] == 'V' || tempSequenceChar[i] == 'L' || tempSequenceChar[i] == 'I' ||
                                             tempSequenceChar[i] == 'M' || tempSequenceChar[i] == 'F' || tempSequenceChar[i] == 'Y' ||
                                             tempSequenceChar[i] == 'W' || tempSequenceChar[i] == 'S' || tempSequenceChar[i] == 'T' ||
                                             tempSequenceChar[i] == 'C' || tempSequenceChar[i] == 'N' || tempSequenceChar[i] == 'Q' ||
                                             tempSequenceChar[i] == 'K' || tempSequenceChar[i] == 'H' || tempSequenceChar[i] == 'R' ||
                                             tempSequenceChar[i] == 'D' || tempSequenceChar[i] == 'E' || tempSequenceChar[i] == 'X'))
                    {
                        sequenceLength++;
                        //if (i > (tempSequenceChar.Length - reductionSeq)) break;
                    }




                }




                lineCounter = 0;
                char[] seqChar = new Char[sequenceLength];
                for (i = 0, j = 0; i < tempSequenceChar.Length; i++)
                {
                    if (tempSequenceChar[i] == '\n') lineCounter++;

                    if (lineCounter >= 1 && (tempSequenceChar[i] == 'G' || tempSequenceChar[i] == 'A' || tempSequenceChar[i] == 'P' ||
                                             tempSequenceChar[i] == 'V' || tempSequenceChar[i] == 'L' || tempSequenceChar[i] == 'I' ||
                                             tempSequenceChar[i] == 'M' || tempSequenceChar[i] == 'F' || tempSequenceChar[i] == 'Y' ||
                                             tempSequenceChar[i] == 'W' || tempSequenceChar[i] == 'S' || tempSequenceChar[i] == 'T' ||
                                             tempSequenceChar[i] == 'C' || tempSequenceChar[i] == 'N' || tempSequenceChar[i] == 'Q' ||
                                             tempSequenceChar[i] == 'K' || tempSequenceChar[i] == 'H' || tempSequenceChar[i] == 'R' ||
                                             tempSequenceChar[i] == 'D' || tempSequenceChar[i] == 'E' || tempSequenceChar[i] == 'X'))
                    {
                        seqChar[j] = tempSequenceChar[i]; j++;
                        //if (i > (tempSequenceChar.Length - reductionSeq)) break;
                    }




                }



                string sequence;
                sequence = new string(seqChar);

                return sequence;

            }

        }


    }
}
