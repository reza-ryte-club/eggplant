using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EggplantCore
{
    public class Primary
    {

        /*

0..............G
1..............A
2..............P
3..............V
4..............L
5..............I
6..............M
7..............F
8..............Y
9..............W
10..............S
11..............T
12..............C
13..............N
14..............Q
15..............K
16..............H
17..............R
18..............D
19..............E

*/
        private char aminoAcid;
        private int count2, count3 = 0;
        private char[] seq = new char[90];
        private int i;
        private int count = 0;
        private char[] str1 = new char[4];
        private int j = 0;
        private string[,] codon = new string[16, 4] { {"TTT","TCT","TAT","TGT"},

            
            {"TTC","TCC","TAC","TGC"},
			{"TTA","TCA","TAA","TGA"},
			{"TTG","TCG","TAG","TGG"},


			{"CTT","CCT","CAT","CGT"},
			{"CTC","CCC","CAC","CGC"},
			{"CTA","CCA","CAA","CGA"},
			{"CTG","CCG","CAG","CGG"},


			{"ATT","ACT","AAT","AGT"},
			{"ATC","ACC","AAC","AGC"},
			{"ATA","ACA","AAA","AGA"},
			{"ATG","ACG","AAG","AGG"},


			{"GTT","GCT","GAT","GGT"},
			{"GTC","GCC","GAC","GGC"},
			{"GTA","GCA","GAA","GGA"},
			{"GTG","GCG","GAG","GGG"},
			};

        public int[] aacidCounter = new int[20];
        /*

        0..............G
        1..............A
        2..............P
        3..............V
        4..............L
        5..............I
        6..............M
        7..............F
        8..............Y
        9..............W
        10..............S
        11..............T
        12..............C
        13..............N
        14..............Q
        15..............K
        16..............H
        17..............R
        18..............D
        19..............E

        */
        //private char[] aacid = new char[] { 'G', 'A', 'P', 'V', 'L', 'I', 'M', 'F', 'Y', 'W', 'S', 'T', 'C', 'N', 'Q', 'K', 'H', 'R', 'D', 'E' };
        //private string[] aacidName = new string[] { "Gly", "Ala", "Pro", "Val", "Leu", "Ile", "Met", "Phe", "Tyr", "Trp", "Ser", "Thr", "Cys", "Asn", "Gln", "Lys", "His", "Arg", "Asp", "Glu" };
        //private int aacidCounterTotal = 0;
        // private char[] seq = new char[90];
        //private int i;
        // private int j = 0;

        private int[,] atomicComposition = new int[20, 5] {
				{2,5,1,2,0}, //G
				{3,7,1,2,0}, //A
				{5,9,1,2,0}, //P
				{5,11,1,2,0}, //V
				{6,13,1,2,0}, //L
				{6,13,1,2,0}, //I
				{5,11,1,2,1}, //M
				{9,11,1,2,0}, //F
				{9,11,1,3,0}, //Y
				{11,12,2,2,0}, //W
				{3,7,1,3,0}, //S
				{4,9,1,3,0}, //T
				{3,7,1,2,1}, //C
				{4,8,2,3,0}, //N
				{5,10,2,3,0}, //Q
				{6,14,2,2,0}, //K
				{6,9,3,2,0}, //H
				{6,14,4,2,0}, //R
				{4,7,1,4,0}, //D
				{5,9,1,4,0} //E
                
				};//C,H,N,O,S



        private double[] absorbance = new double[2];
        private double molecularWeight;




        public static string transcription(string a)
        {
            int i;
            string b, errorMessage = "Not a valid DNA Sequence";
            if (a.Contains("B") || a.Contains("D") || a.Contains("E") || a.Contains("F") || a.Contains("P") || a.Contains("H") ||
                a.Contains("I") || a.Contains("J") || a.Contains("K") || a.Contains("L") || a.Contains("M") || a.Contains("N") ||
                a.Contains("O") || a.Contains("Q") || a.Contains("R") || a.Contains("S") || a.Contains("V") ||
                a.Contains("W") || a.Contains("X") || a.Contains("Y") || a.Contains("Z")) { return errorMessage; }
            b = a.Replace("T", "U");

            return b;

        }


        public static string translate(string a)
        {
            char[] a2 = new char[4]; int j = 0, count = 0; char aminoAcid;
            char[] a1 = a.ToCharArray();
            string translatedSequence = null;
            int seqLength = a.Length;

            if (a.Length == 0) return "empty sequence";

            for (int i = 0; i < seqLength; i++)
            {
                a2[j] = a1[i];
                count++; j++;
                if (count % 3 == 0)
                {
                    a2[3] = '\0'; j = 0;
                    aminoAcid = aacidDet(a2);

                    if (aminoAcid == 'Z') translatedSequence = translatedSequence + " Stop ";
                    else if (aminoAcid == 'B') translatedSequence = translatedSequence + "\n";
                    else translatedSequence = translatedSequence + aminoAcid;
                }

            }



            return translatedSequence;

        }



        private static char aacidDet(char[] a2)
        {
            string str = new string(a2);
            if (str.CompareTo("TTT") == 0) return 'F';///if string is same strcmp returns 0
            else if (str.CompareTo("TTC") == 0) return 'F';
            else if (str.CompareTo("TTA") == 0) return 'L';
            else if (str.CompareTo("TTG") == 0) return 'L';
            else if (str.CompareTo("CTT") == 0) return 'L';
            else if (str.CompareTo("CTC") == 0) return 'L';
            else if (str.CompareTo("CTA") == 0) return 'L';
            else if (str.CompareTo("CTG") == 0) return 'L';
            else if (str.CompareTo("ATT") == 0) return 'I';
            else if (str.CompareTo("ATC") == 0) return 'I';
            else if (str.CompareTo("ATA") == 0) return 'I';
            else if (str.CompareTo("ATG") == 0) return 'M';
            else if (str.CompareTo("GTT") == 0) return 'V';
            else if (str.CompareTo("GTC") == 0) return 'V';
            else if (str.CompareTo("GTA") == 0) return 'V';
            else if (str.CompareTo("GTG") == 0) return 'V';
            else if (str.CompareTo("TCT") == 0) return 'S';
            else if (str.CompareTo("TCC") == 0) return 'S';
            else if (str.CompareTo("TCA") == 0) return 'S';
            else if (str.CompareTo("TCG") == 0) return 'S';
            else if (str.CompareTo("CCT") == 0) return 'P';
            else if (str.CompareTo("CCC") == 0) return 'P';
            else if (str.CompareTo("CCA") == 0) return 'P';
            else if (str.CompareTo("CCG") == 0) return 'P';
            else if (str.CompareTo("ACT") == 0) return 'T';
            else if (str.CompareTo("ACC") == 0) return 'T';
            else if (str.CompareTo("ACA") == 0) return 'T';
            else if (str.CompareTo("ACG") == 0) return 'T';
            else if (str.CompareTo("GCT") == 0) return 'A';
            else if (str.CompareTo("GCC") == 0) return 'A';
            else if (str.CompareTo("GCA") == 0) return 'A';
            else if (str.CompareTo("GCG") == 0) return 'A';
            else if (str.CompareTo("TAT") == 0) return 'Y';
            else if (str.CompareTo("TAC") == 0) return 'Y';
            else if (str.CompareTo("TAA") == 0) return 'Z';// z MEANS STOP
            else if (str.CompareTo("TAG") == 0) return 'Z';

            else if (str.CompareTo("CAT") == 0) return 'H';
            else if (str.CompareTo("CAC") == 0) return 'H';

            else if (str.CompareTo("CAA") == 0) return 'Q';
            else if (str.CompareTo("CAG") == 0) return 'Q';
            else if (str.CompareTo("AAT") == 0) return 'N';
            else if (str.CompareTo("AAC") == 0) return 'N';
            else if (str.CompareTo("AAA") == 0) return 'K';
            else if (str.CompareTo("AAG") == 0) return 'K';



            else if (str.CompareTo("GAT") == 0) return 'D';
            else if (str.CompareTo("GAC") == 0) return 'D';
            else if (str.CompareTo("GAA") == 0) return 'E';
            else if (str.CompareTo("GAG") == 0) return 'E';


            else if (str.CompareTo("TGT") == 0) return 'C';
            else if (str.CompareTo("TGC") == 0) return 'C';
            else if (str.CompareTo("TGA") == 0) return 'Z';
            else if (str.CompareTo("TGG") == 0) return 'W';

            else if (str.CompareTo("CGT") == 0) return 'R';
            else if (str.CompareTo("CGC") == 0) return 'R';
            else if (str.CompareTo("CGA") == 0) return 'R';
            else if (str.CompareTo("CGG") == 0) return 'R';



            else if (str.CompareTo("AGT") == 0) return 'S';
            else if (str.CompareTo("AGC") == 0) return 'S';
            else if (str.CompareTo("AGA") == 0) return 'R';
            else if (str.CompareTo("AGG") == 0) return 'R';


            else if (str.CompareTo("GGT") == 0) return 'G';
            else if (str.CompareTo("GGC") == 0) return 'G';
            else if (str.CompareTo("GGA") == 0) return 'G';
            else if (str.CompareTo("GGG") == 0) return 'G';


            else return 'B';/// B means invalid

        }




        public static int[] aminoAcidCounter(string aminoAcidSeq)
        {
            int[] aacidCounter = new int[20];
            char[] seq = aminoAcidSeq.ToCharArray();
            int aacidCounterTotal = 0;
            int i;

            for (i = 0; i < 20; i++) aacidCounter[i] = 0;
            for (i = 0; i < aminoAcidSeq.Length; i++)
            {


                if (seq[i] == 'G' || seq[i] == 'A' || seq[i] == 'P' || seq[i] == 'V' || seq[i] == 'L'
                    || seq[i] == 'I' || seq[i] == 'M' || seq[i] == 'F' || seq[i] == 'Y' || seq[i] == 'W'
                    || seq[i] == 'S' || seq[i] == 'T' || seq[i] == 'C' || seq[i] == 'N' || seq[i] == 'Q'
                    || seq[i] == 'K' || seq[i] == 'H' || seq[i] == 'R' || seq[i] == 'D' || seq[i] == 'E')
                {
                    aacidCounterTotal++;
                    if (seq[i] == 'G') aacidCounter[0]++;
                    if (seq[i] == 'A') aacidCounter[1]++;
                    if (seq[i] == 'P') aacidCounter[2]++;
                    if (seq[i] == 'V') aacidCounter[3]++;
                    if (seq[i] == 'L') aacidCounter[4]++;
                    if (seq[i] == 'I') aacidCounter[5]++;
                    if (seq[i] == 'M') aacidCounter[6]++;
                    if (seq[i] == 'F') aacidCounter[7]++;
                    if (seq[i] == 'Y') aacidCounter[8]++;
                    if (seq[i] == 'W') aacidCounter[9]++;
                    if (seq[i] == 'S') aacidCounter[10]++;
                    if (seq[i] == 'T') aacidCounter[11]++;
                    if (seq[i] == 'C') aacidCounter[12]++;
                    if (seq[i] == 'N') aacidCounter[13]++;
                    if (seq[i] == 'Q') aacidCounter[14]++;
                    if (seq[i] == 'K') aacidCounter[15]++;
                    if (seq[i] == 'H') aacidCounter[16]++;
                    if (seq[i] == 'R') aacidCounter[17]++;
                    if (seq[i] == 'D') aacidCounter[18]++;
                    if (seq[i] == 'E') aacidCounter[19]++;

                }


            }


            return aacidCounter;
        }
        public static int positiveAminoAcidCounter(string aminoAcidSeq)
        {
            int i;
            int[] aacidCounter = new int[20];

            int positiveCounter = 0;

            char[] sequence = aminoAcidSeq.ToCharArray();


            for (i = 0; i < aminoAcidSeq.Length; i++)


                //if (sequence[i] == 'K' || sequence[i] == 'H' || sequence[i] == 'R') positiveCounter++;
                if (sequence[i] == 'K' || sequence[i] == 'R') positiveCounter++;

            return positiveCounter;
        }


        public static int negativeAminoAcidCounter(string aminoAcidSeq)
        {
            int i;
            int[] aacidCounter = new int[20];

            int negativeCounter = 0;

            char[] sequence = aminoAcidSeq.ToCharArray();



            for (i = 0; i < aminoAcidSeq.Length; i++)




                if (sequence[i] == 'D' || sequence[i] == 'E') negativeCounter++;


            return negativeCounter;
        }



        public static int polarAminoAcidCounter(string aminoAcidSeq)
        {
            int i;
            int[] aacidCounter = new int[20];

            int polarCounter = 0;

            char[] sequence = aminoAcidSeq.ToCharArray();



            for (i = 0; i < aminoAcidSeq.Length; i++)


                if (sequence[i] == 'S' || sequence[i] == 'T' || sequence[i] == 'C' || sequence[i] == 'N' || sequence[i] == 'Q') polarCounter++;


            return polarCounter;
        }




        public static int nonPolarAminoAcidCounter(string aminoAcidSeq)
        {
            int i;
            int[] aacidCounter = new int[20];

            int nonPolarCounter = 0;

            char[] sequence = aminoAcidSeq.ToCharArray();



            for (i = 0; i < aminoAcidSeq.Length; i++)


                if (sequence[i] == 'G' || sequence[i] == 'A' || sequence[i] == 'P' || sequence[i] == 'V' || sequence[i] == 'L' || sequence[i] == 'I' || sequence[i] == 'M') nonPolarCounter++;
            return nonPolarCounter;
        }



        public static int aromaticAminoAcidCounter(string aminoAcidSeq)
        {
            int i;
            int[] aacidCounter = new int[20];

            int aromaticCounter = 0;

            char[] sequence = aminoAcidSeq.ToCharArray();



            for (i = 0; i < aminoAcidSeq.Length; i++)


                if (sequence[i] == 'F' || sequence[i] == 'Y' || sequence[i] == 'W') aromaticCounter++;

            return aromaticCounter;
        }


        public static int carbonCounter(string seq)
        {
            int noOfCarbonAtoms = 0, i, j;
            int[,] atomicComposition = {
				{2,5,1,2,0}, //G
				{3,7,1,2,0}, //A
				{5,9,1,2,0}, //P
				{5,11,1,2,0}, //V
				{6,13,1,2,0}, //L
				{6,13,1,2,0}, //I
				{5,11,1,2,1}, //M
				{9,11,1,2,0}, //F
				{9,11,1,3,0}, //Y
				{11,12,2,2,0}, //W
				{3,7,1,3,0}, //S
				{4,9,1,3,0}, //T
				{3,7,1,2,1}, //C
				{4,8,2,3,0}, //N
				{5,10,2,3,0}, //Q
				{6,14,2,2,0}, //K
				{6,9,3,2,0}, //H
				{6,14,4,2,0}, //R
				{4,7,1,4,0}, //D
				{5,9,1,4,0} //E
                
				};//C,H,N,O,S


            int[] aacidCounter = new int[20];
            aacidCounter = aminoAcidCounter(seq);



            for (i = 0; i < 20; i++)
                if (seq.Length > 0)
                {
                    for (j = 0; j < aacidCounter[i]; j++)
                        noOfCarbonAtoms += atomicComposition[i, 0];//2
                }
            return noOfCarbonAtoms;


        }

        public static int hydrogenCounter(string seq)
        {
            int noOfHydrogenAtoms = 0, i, j;
            int[,] atomicComposition = {
				{2,5,1,2,0}, //G
				{3,7,1,2,0}, //A
				{5,9,1,2,0}, //P
				{5,11,1,2,0}, //V
				{6,13,1,2,0}, //L
				{6,13,1,2,0}, //I
				{5,11,1,2,1}, //M
				{9,11,1,2,0}, //F
				{9,11,1,3,0}, //Y
				{11,12,2,2,0}, //W
				{3,7,1,3,0}, //S
				{4,9,1,3,0}, //T
				{3,7,1,2,1}, //C
				{4,8,2,3,0}, //N
				{5,10,2,3,0}, //Q
				{6,14,2,2,0}, //K
				{6,9,3,2,0}, //H
				{6,14,4,2,0}, //R
				{4,7,1,4,0}, //D
				{5,9,1,4,0} //E
                
				};//C,H,N,O,S

            int[] aacidCounter = new int[20];
            aacidCounter = aminoAcidCounter(seq);




            for (i = 0; i < 20; i++)
                if (seq.Length > 0)
                {
                    for (j = 0; j < aacidCounter[i]; j++)
                        noOfHydrogenAtoms += atomicComposition[i, 1];//2
                }
            noOfHydrogenAtoms = noOfHydrogenAtoms - (2 * seq.Length - 2);
            return noOfHydrogenAtoms;


        }


        public static int nitrogenCounter(string seq)
        {
            int noOfNytrogenAtoms = 0, i, j;
            int[,] atomicComposition = {
				{2,5,1,2,0}, //G
				{3,7,1,2,0}, //A
				{5,9,1,2,0}, //P
				{5,11,1,2,0}, //V
				{6,13,1,2,0}, //L
				{6,13,1,2,0}, //I
				{5,11,1,2,1}, //M
				{9,11,1,2,0}, //F
				{9,11,1,3,0}, //Y
				{11,12,2,2,0}, //W
				{3,7,1,3,0}, //S
				{4,9,1,3,0}, //T
				{3,7,1,2,1}, //C
				{4,8,2,3,0}, //N
				{5,10,2,3,0}, //Q
				{6,14,2,2,0}, //K
				{6,9,3,2,0}, //H
				{6,14,4,2,0}, //R
				{4,7,1,4,0}, //D
				{5,9,1,4,0} //E
                
				};//C,H,N,O,S

            int[] aacidCounter = new int[20];
            aacidCounter = aminoAcidCounter(seq);

            for (i = 0; i < 20; i++)
                if (seq.Length > 0)
                {
                    for (j = 0; j < aacidCounter[i]; j++)
                        noOfNytrogenAtoms += atomicComposition[i, 2];
                }
            return noOfNytrogenAtoms;


        }

        public static string acidComposition(string seq)
        {

            char[] aacid = new char[] { 'G', 'A', 'P', 'V', 'L', 'I', 'M', 'F', 'Y', 'W', 'S', 'T', 'C', 'N', 'Q', 'K', 'H', 'R', 'D', 'E' };
            int[] aacidCounter = new int[20];
            aacidCounter = aminoAcidCounter(seq);
            string outPut = "Amoino Acid Composition:\n \n" + "\nG\t" + aacidCounter[0] + "\t" + ((double)aacidCounter[0] * 100 / (double)seq.Length).ToString("F2") + "%" +
                                                             "\nA\t" + aacidCounter[1] + "\t" + ((double)aacidCounter[1] * 100 / (double)seq.Length).ToString("F2") + "%" +
                                                             "\nP\t" + aacidCounter[2] + "\t" + ((double)aacidCounter[2] * 100 / (double)seq.Length).ToString("F2") + "%" +
                                                             "\nV\t" + aacidCounter[3] + "\t" + ((double)aacidCounter[3] * 100 / (double)seq.Length).ToString("F2") + "%" +
                                                             "\nL\t" + aacidCounter[4] + "\t" + ((double)aacidCounter[4] * 100 / (double)seq.Length).ToString("F2") + "%" +
                                                             "\nI\t" + aacidCounter[5] + "\t" + ((double)aacidCounter[5] * 100 / (double)seq.Length).ToString("F2") + "%" +
                                                             "\nM\t" + aacidCounter[6] + "\t" + ((double)aacidCounter[6] * 100 / (double)seq.Length).ToString("F2") + "%" +
                                                             "\nF\t" + aacidCounter[7] + "\t" + ((double)aacidCounter[7] * 100 / (double)seq.Length).ToString("F2") + "%" +
                                                             "\nY\t" + aacidCounter[8] + "\t" + ((double)aacidCounter[8] * 100 / (double)seq.Length).ToString("F2") + "%" +
                                                             "\nW\t" + aacidCounter[9] + "\t" + ((double)aacidCounter[9] * 100 / (double)seq.Length).ToString("F2") + "%" +
                                                             "\nS\t" + aacidCounter[10] + "\t" + ((double)aacidCounter[10] * 100 / (double)seq.Length).ToString("F2") + "%" +
                                                             "\nT\t" + aacidCounter[11] + "\t" + ((double)aacidCounter[11] * 100 / (double)seq.Length).ToString("F2") + "%" +
                                                             "\nC\t" + aacidCounter[12] + "\t" + ((double)aacidCounter[12] * 100 / (double)seq.Length).ToString("F2") + "%" +
                                                             "\nN\t" + aacidCounter[13] + "\t" + ((double)aacidCounter[13] * 100 / (double)seq.Length).ToString("F2") + "%" +
                                                             "\nQ\t" + aacidCounter[14] + "\t" + ((double)aacidCounter[14] * 100 / (double)seq.Length).ToString("F2") + "%" +
                                                             "\nK\t" + aacidCounter[15] + "\t" + ((double)aacidCounter[15] * 100 / (double)seq.Length).ToString("F2") + "%" +
                                                             "\nH\t" + aacidCounter[16] + "\t" + ((double)aacidCounter[16] * 100 / (double)seq.Length).ToString("F2") + "%" +
                                                             "\nR\t" + aacidCounter[17] + "\t" + ((double)aacidCounter[17] * 100 / (double)seq.Length).ToString("F2") + "%" +
                                                             "\nD\t" + aacidCounter[18] + "\t" + ((double)aacidCounter[18] * 100 / (double)seq.Length).ToString("F2") + "%" +
                                                             "\nE\t" + aacidCounter[19] + "\t" + ((double)aacidCounter[19] * 100 / (double)seq.Length).ToString("F2") + "%";



            return outPut;

        }

        public static int oxygenCounter(string seq)
        {
            int noOfOxygenAtoms = 0, i, j;
            int[,] atomicComposition = {
				{2,5,1,2,0}, //G
				{3,7,1,2,0}, //A
				{5,9,1,2,0}, //P
				{5,11,1,2,0}, //V
				{6,13,1,2,0}, //L
				{6,13,1,2,0}, //I
				{5,11,1,2,1}, //M
				{9,11,1,2,0}, //F
   				{9,11,1,3,0}, //Y
				{11,12,2,2,0}, //W
				{3,7,1,3,0}, //S
				{4,9,1,3,0}, //T
				{3,7,1,2,1}, //C
				{4,8,2,3,0}, //N
				{5,10,2,3,0}, //Q
				{6,14,2,2,0}, //K
				{6,9,3,2,0}, //H
				{6,14,4,2,0}, //R
				{4,7,1,4,0}, //D
				{5,9,1,4,0} //E
                
				};//C,H,N,O,S

            int[] aacidCounter = new int[20];
            aacidCounter = aminoAcidCounter(seq);




            for (i = 0; i < 20; i++)
                if (seq.Length > 0)
                {
                    for (j = 0; j < aacidCounter[i]; j++)
                        noOfOxygenAtoms += atomicComposition[i, 3];
                }
            noOfOxygenAtoms = noOfOxygenAtoms - (seq.Length - 1);

            return noOfOxygenAtoms;


        }


        public static int sulfurCounter(string seq)
        {
            int noOfSulfurAtoms = 0, i, j;
            int[,] atomicComposition = {
				{2,5,1,2,0}, //G
				{3,7,1,2,0}, //A
				{5,9,1,2,0}, //P
				{5,11,1,2,0}, //V
				{6,13,1,2,0}, //L
				{6,13,1,2,0}, //I
				{5,11,1,2,1}, //M
				{9,11,1,2,0}, //F
				{9,11,1,3,0}, //Y
				{11,12,2,2,0}, //W
				{3,7,1,3,0}, //S
				{4,9,1,3,0}, //T
				{3,7,1,2,1}, //C
				{4,8,2,3,0}, //N
				{5,10,2,3,0}, //Q
				{6,14,2,2,0}, //K
				{6,9,3,2,0}, //H
				{6,14,4,2,0}, //R
				{4,7,1,4,0}, //D
				{5,9,1,4,0} //E
                
				};//C,H,N,O,S

            int[] aacidCounter = new int[20];
            aacidCounter = aminoAcidCounter(seq);


            for (i = 0; i < 20; i++)
                if (seq.Length > 0)
                {
                    for (j = 0; j < aacidCounter[i]; j++)
                        noOfSulfurAtoms += atomicComposition[i, 4];
                }
            return noOfSulfurAtoms;


        }

        public static int totalNoOfAtoms(string seq)
        {

            int c = carbonCounter(seq);
            int h = hydrogenCounter(seq);
            int n = nitrogenCounter(seq);
            int o = oxygenCounter(seq);
            int s = sulfurCounter(seq);
            int totalAtoms = c + h + n + o + s;

            return totalAtoms;

        }



        public static double getMolecularWeight(string seq)
        {


            int c = carbonCounter(seq);
            int h = hydrogenCounter(seq);
            int n = nitrogenCounter(seq);
            int o = oxygenCounter(seq);
            int s = sulfurCounter(seq);
            double molecularWeight;
            molecularWeight = c * 12.001 + h * 1.00794 + n * 14.00674 + o * 15.9994 + s * 32.066;

            return molecularWeight;
        }

        public static int tyrCounter(string aminoAcidSeq)
        {
            int i;
            //int[] aacidCounter = new int[20];

            int yCounter = 0;

            char[] sequence = aminoAcidSeq.ToCharArray();



            for (i = 0; i < aminoAcidSeq.Length; i++)


                if (sequence[i] == 'Y') yCounter++;

            return yCounter;


        }
        public static int trpCounter(string aminoAcidSeq)
        {
            int i;
            int[] aacidCounter = new int[20];

            int wCounter = 0;

            char[] sequence = aminoAcidSeq.ToCharArray();



            for (i = 0; i < aminoAcidSeq.Length; i++)


                if (sequence[i] == 'W') wCounter++;

            return wCounter;


        }


        public static int cysCounter(string aminoAcidSeq)
        {
            int i;
            int[] aacidCounter = new int[20];

            int cCounter = 0;

            char[] sequence = aminoAcidSeq.ToCharArray();



            for (i = 0; i < aminoAcidSeq.Length; i++)


                if (sequence[i] == 'C') cCounter++;

            return cCounter;


        }

        public static int alaCounter(string aminoAcidSeq)
        {
            int i;

            int aCounter = 0;

            char[] sequence = aminoAcidSeq.ToCharArray();



            for (i = 0; i < aminoAcidSeq.Length; i++)


                if (sequence[i] == 'A') aCounter++;

            return aCounter;


        }

        public static int valCounter(string aminoAcidSeq)
        {
            int i;

            int vCounter = 0;

            char[] sequence = aminoAcidSeq.ToCharArray();



            for (i = 0; i < aminoAcidSeq.Length; i++)


                if (sequence[i] == 'V') vCounter++;

            return vCounter;


        }


        public static int ileCounter(string aminoAcidSeq)
        {
            int i;

            int iCounter = 0;

            char[] sequence = aminoAcidSeq.ToCharArray();



            for (i = 0; i < aminoAcidSeq.Length; i++)


                if (sequence[i] == 'I') iCounter++;

            return iCounter;


        }


        public static int leuCounter(string aminoAcidSeq)
        {
            int i;

            int lCounter = 0;

            char[] sequence = aminoAcidSeq.ToCharArray();



            for (i = 0; i < aminoAcidSeq.Length; i++)


                if (sequence[i] == 'L') lCounter++;

            return lCounter;


        }
        public static int[] extinctionCoefficient(string seq)
        {


            int[] e = new int[2];
            /*
            E1 = Numb(Tyr)*Ext(Tyr) + Numb(Trp)*Ext(Trp) +Numb(Cystine)*Ext(Cystine)

            E2 = Numb(Tyr)*Ext(Tyr) + Numb(Trp)*Ext(Trp)

            where (for proteins in water measured at 280 nm)
            Ext(Tyr) = 1490, Ext(Trp) = 5500, Ext(Cystine) = 125;

            */

            e[0] = tyrCounter(seq) * 1490 + trpCounter(seq) * 5500 + (cysCounter(seq) / 2) * 125;
            e[1] = tyrCounter(seq) * 1490 + trpCounter(seq) * 5500;
            // if (e[0] != 0 || e[1] != 0)
            return e;


            //printf("As there are no Trp, Tyr or Cys in the region considered, your proteinshould not be visible by UV spectrophotometry.\n");


        }


        public static double aliphaticIndex(string seq)
        {


            double aIndex, a = 2.9, b = 3.9;
            //Aliphatic index = X(Ala) + a * X(Val) + b * ( X(Ile) + X(Leu) )


            aIndex = alaCounter(seq) + a * valCounter(seq) + b * (ileCounter(seq) + leuCounter(seq));


            return aIndex;


        }
        public static double gravy(string seq)
        {
            char[] aacid = new char[] { 'G', 'A', 'P', 'V', 'L', 'I', 'M', 'F', 'Y', 'W', 'S', 'T', 'C', 'N', 'Q', 'K', 'H', 'R', 'D', 'E' };
            int[] aacidCounter = new int[20];
            aacidCounter = aminoAcidCounter(seq);

            double[] gravyParam = new double[20] { -0.4, 1.8, -1.6, 4.2, 3.8, 
                                             4.5, 1.9, 2.8, -1.3, -0.9,
                                            -0.8, -0.7, 2.5, -3.5, -3.5,
                                            -3.9, -3.2, -4.5, -3.5, -3.5 };
            double gravyTotal = 0.0, gravyValue = 0.0;

            for (int i = 0; i < 20; i++)
                gravyTotal = gravyTotal + ((float)aacidCounter[i] * gravyParam[i]);
            //  gravyTotal = gravyTotal + ((float)p.aacidCounter[i] * gravyParam[i]);

            gravyValue = gravyTotal / seq.Length;

            return gravyValue;
        }





        public static double[] absorbancePrimary(string seq)
        {
            double[] absorbance = new double[2];

            Array.Copy(extinctionCoefficient(seq), absorbance, 2);
            for (int i = 0; i < 2; i++) absorbance[i] = absorbance[i] / getMolecularWeight(seq);
            return absorbance;
        }



        public static string halfLifePrimary(string seq)
        {
            int i;
            char[] sequence = seq.ToCharArray();
            string[,] halfLife = new string[20, 3] {
/*
			Gly	30 hour	>20 hour	>10 hour 		G
			Ala	4.4 hour	>20 hour	>10 hour   	A
			Pro	>20 hour	>20 hour	?		P
			Val	100 hour	>20 hour	>10 hour	V
			Leu	5.5 hour	3 min	2 min			L
			Ile	20 hour	30 min	>10 hour			I
			Met	30 hour	>20 hour	>10 hour		M
			Phe	1.1 hour	3 min	2 min			F
			Tyr	2.8 hour	10 min	2 min			Y
			Trp	2.8 hour	3 min	2 min			W
			Ser	1.9 hour	>20 hour	>10 hour	S
			Thr	7.2 hour	>20 hour	>10 hour	T
			Cys	1.2 hour	>20 hour	>10 hour	C
			Asn	1.4 hour	3 min	>10 hour		N
			Gln	0.8 hour	10 min	>10 hour		Q
			Lys	1.3 hour	3 min	2 min			K
			His	3.5 hour	10 min	>10 hour		H
			Arg	1 hour	2 min	2 min				R
			Asp	1.1 hour	3 min	>10 hour		D
			Glu	1 hour	30 min	>10 hour			E

*/

    {"30 hour",">20 hour",">10 hour"},// 		G
    {"4.4 hour",">20 hour",">10 hour"},//   		A
    {">20 hour",">20 hour","?"},//			P
    {"100 hour",">20 hour",">10 hour"},//		V
    {"5.5 hour","3 min","2 min"},//			L
    {"20 hour","30 min",">10 hour"},//		I
    {"30 hour",">20 hour",">10 hour"},//		M
    {"1.1 hour","3 min","2 min"},//			F
    {"2.8 hour","10 min","2 min"},//			Y
    {"2.8 hour","3 min","2 min"},//			W
    {"1.9 hour",">20 hour",">10 hour"},//		S
    {"7.2 hour",">20 hour",">10 hour"},//		T
    {"1.2 hour",">20 hour",">10 hour"},//		C
    {"1.4 hour","3 min",">10 hour"},//		N
    {"0.8 hour","10 min",">10 hour"},//		Q
    {"1.3 hour","3 min","2 min"},//			K
    {"3.5 hour","10 min",">10 hour"},//		H
    {"1 hour","2 min","2 min"},//			R
    {"1.1 hour","3 min",">10 hour"},//		D
    {"1 hour","30 min",">10 hour"}//			E
    };//Mammalian,Yeast,E.coli



            string halfLifeReturn = " ";
            char[] aacid = new char[] { 'G', 'A', 'P', 'V', 'L', 'I', 'M', 'F', 'Y', 'W', 'S', 'T', 'C', 'N', 'Q', 'K', 'H', 'R', 'D', 'E' };

            for (i = 0; i < 20; i++)
                if (sequence[0] == aacid[i])
                {
                    halfLifeReturn = "The estimated half-life is:\n" + halfLife[i, 0] + "  (mammalian reticulocytes, in vitro)\n" + halfLife[i, 1] + "  (yeast, in vivo)\n" + halfLife[i, 2] + "(Escherichia coli, in vivo)\n";
                    break;
                }

            return halfLifeReturn;


        }













    }
}
