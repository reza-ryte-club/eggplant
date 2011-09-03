#include<stdio.h>

int main(){
int aacidCounter[20];

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
char aacid[20]={'G','A','P','V','L','I','M','F','Y','W','S','T','C','N','Q','K','H','R','D','E'};
char *aacidName[]={"Gly","Ala","Pro","Val","Leu","Ile","Met","Phe","Tyr","Trp","Ser","Thr","Cys","Asn","Gln","Lys","His","Arg","Asp","Glu"};
int aacidCounterTotal=0;
char seq[90];
int i;
int j=0;
int positiveCounter = 0;
int negativeCounter = 0;
int polarCounter = 0;
int nonpolarCounter = 0;
int aromaticCounter = 0;
int carbonCounter = 0;
int hydrogenCounter = 0;
int nitrogenCounter = 0;
int oxygenCounter = 0;
int sulferCounter = 0;
int totalAtoms = 0;
int atomicComposition [20][5] = {
				2,5,1,2,0, //G
				3,7,1,2,0, //A
				5,9,1,2,0, //P
				5,11,1,2,0, //V
				6,13,1,2,0, //L
				6,13,1,2,0, //I
				5,11,1,2,1, //M
				9,11,1,2,0, //F
				9,11,1,3,0, //Y
				11,12,2,2,0, //W
				3,7,1,3,0, //S
				4,9,1,3,0, //T
				3,7,1,2,1, //C
				4,8,2,3,0, //N
				5,10,2,3,0, //Q
				6,14,2,2,0, //K
				6,9,3,2,0, //H
				6,14,4,2,0, //R
				4,7,1,4,0, //D
				5,9,1,4,0 //E

				};//C,H,N,O,S

char *halfLife[][3] = {
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

			"30 hour",">20 hour",">10 hour",// 		G
			"4.4 hour",">20 hour",">10 hour",//   		A
			">20 hour",">20 hour","?",//			P
			"100 hour",">20 hour",">10 hour",//		V
			"5.5 hour","3 min","2 min",//			L
			"20 hour","30 min",">10 hour",//		I
			"30 hour",">20 hour",">10 hour",//		M
			"1.1 hour","3 min","2 min",//			F
			"2.8 hour","10 min","2 min",//			Y
			"2.8 hour","3 min","2 min",//			W
			"1.9 hour",">20 hour",">10 hour",//		S
			"7.2 hour",">20 hour",">10 hour",//		T
			"1.2 hour",">20 hour",">10 hour",//		C
			"1.4 hour","3 min",">10 hour",//		N
			"0.8 hour","10 min",">10 hour",//		Q
			"1.3 hour","3 min","2 min",//			K
			"3.5 hour","10 min",">10 hour",//		H
			"1 hour","2 min","2 min",//			R
			"1.1 hour","3 min",">10 hour",//		D
			"1 hour","30 min",">10 hour"//			E
			"",""//terminate table with null string
			};//Mammalian,Yeast,E.coli

int e1,e2 ;//Extinction coefficient
float aIndex,a=2.9,b=3.9;// Aliphatic Index
float GRAVYparam[20] = {-0.4,1.8,-1.6,4.2,3.8,4.5,1.9,2.8,-1.3,-0.9,-0.8,-0.7,2.5,-3.5,-3.5,-3.9,-3.2,-4.5,-3.5,-3.5};
float GRAVYtotal=0.0,GRAVY;
float absorbance[2];
float molecularWeight;

for(i=0;i<20;i++)aacidCounter[i]=0;

printf("Enter the sequence \n");

for(i = 0;i<90;i++)
			{
				scanf("%c",&seq[i]);

				if(seq[i]=='\n')break;

				if(seq[i]=='G'|| seq[i]=='A'|| seq[i]=='P'|| seq[i]=='V' || seq[i]=='L' || seq[i]=='I'|| seq[i]=='M' || seq[i]=='F' || seq[i]=='Y' || seq[i]=='W' || seq[i]=='S' || seq[i]=='T' || seq[i]=='C' || seq[i]=='N' || seq[i]=='Q' || seq[i]=='K' || seq[i]=='H' || seq[i]=='R' || seq[i]=='D' || seq[i]=='E')
				{
				aacidCounterTotal++;
				if(seq[i]=='G')aacidCounter[0]++;
				if(seq[i]=='A')aacidCounter[1]++;
				if(seq[i]=='P')aacidCounter[2]++;
				if(seq[i]=='V')aacidCounter[3]++;
				if(seq[i]=='L')aacidCounter[4]++;
				if(seq[i]=='I')aacidCounter[5]++;
				if(seq[i]=='M')aacidCounter[6]++;
				if(seq[i]=='F')aacidCounter[7]++;
				if(seq[i]=='Y')aacidCounter[8]++;
				if(seq[i]=='W')aacidCounter[9]++;
				if(seq[i]=='S')aacidCounter[10]++;
				if(seq[i]=='T')aacidCounter[11]++;
				if(seq[i]=='C')aacidCounter[12]++;
				if(seq[i]=='N')aacidCounter[13]++;
				if(seq[i]=='Q')aacidCounter[14]++;
				if(seq[i]=='K')aacidCounter[15]++;
				if(seq[i]=='H')aacidCounter[16]++;
				if(seq[i]=='R')aacidCounter[17]++;
				if(seq[i]=='D')aacidCounter[18]++;
				if(seq[i]=='E')aacidCounter[19]++;





				if(seq[i]=='K'||seq[i]=='H'||seq[i]=='R')positiveCounter++;
				if(seq[i]=='D'||seq[i]=='E')negativeCounter++;
				if(seq[i]=='S'||seq[i]=='T'||seq[i]=='C'||seq[i]=='N'||seq[i]=='Q')polarCounter++;
				if(seq[i]=='G'||seq[i]=='A'||seq[i]=='P'||seq[i]=='V'||seq[i]=='L'||seq[i]=='I'||seq[i]=='M')nonpolarCounter++;      					if(seq[i]=='F'||seq[i]=='Y'||seq[i]=='W')aromaticCounter++;

				}


			}




printf("\n");
printf("No of Amino Acids: %d \n",aacidCounterTotal);

printf("No of positive Amino Acids: %d \n",positiveCounter);
printf("No of negative Amino Acids: %d \n",negativeCounter);
printf("No of polar Amino Acids: %d \n",polarCounter);
printf("No of nonpolar Amino Acids: %d \n",nonpolarCounter);
printf("No of aromatic Amino Acids: %d \n",aromaticCounter);


printf("Amino acid composition\n\n\n\n");
for(i=0;i<20;i++){
			printf("%c \t %d   %f \n",aacid[i],aacidCounter[i],(float)aacidCounter[i]*100.00/(float)aacidCounterTotal);

			}




for(i=0;i<20;i++)
			{

			if(aacidCounter[i]>0)
			for(j=0;j<aacidCounter[i];j++)
					{carbonCounter += atomicComposition[i][0] ;//2
					 hydrogenCounter += atomicComposition[i][1];//5
					 nitrogenCounter += atomicComposition[i][2];//1
					 oxygenCounter += atomicComposition[i][3];//2
					 sulferCounter += atomicComposition[i][4];//0
					}

			}


			hydrogenCounter = hydrogenCounter - (2*aacidCounterTotal - 2);
			oxygenCounter = oxygenCounter - (aacidCounterTotal-1);


printf("\n\nAtomic Composition\n");

printf("Carbon     C\t %d\n",carbonCounter);
printf("Hydrogen   H\t %d\n",hydrogenCounter);
printf("Nitrogen   N\t %d\n",nitrogenCounter);
printf("Oxygen     O\t %d\n",oxygenCounter);
printf("Sulfer     S\t %d\n",sulferCounter);


printf("\nFormula:");

if(carbonCounter>0)printf("C%d ",carbonCounter);
if(hydrogenCounter>0)printf("H%d ",hydrogenCounter);
if(nitrogenCounter>0)printf("N%d ",nitrogenCounter);
if(oxygenCounter>0)printf("O%d ",oxygenCounter);
if(sulferCounter>0)printf("S%d ",sulferCounter);

printf("\n");

totalAtoms = carbonCounter + hydrogenCounter + nitrogenCounter + oxygenCounter + sulferCounter;
printf("Total number of atoms:  %d\n",totalAtoms);

molecularWeight = carbonCounter*12.001 + hydrogenCounter*1.00794 + nitrogenCounter*14.00674 + oxygenCounter*15.9994 + sulferCounter*32.066;
printf("Molecular weight %f\n\n", molecularWeight);







printf("Extinction Coefficient\n");

/*
E1 = Numb(Tyr)*Ext(Tyr) + Numb(Trp)*Ext(Trp) Numb(Cystine)*Ext(Cystine)

E2 = Numb(Tyr)*Ext(Tyr) + Numb(Trp)*Ext(Trp)

where (for proteins in water measured at 280 nm)
Ext(Tyr) = 1490, Ext(Trp) = 5500, Ext(Cystine) = 125;

*/

e1 = aacidCounter[8]*1490 + aacidCounter[9]*5500+ (aacidCounter[12]/2)*125;
e2 =  aacidCounter[8]*1490 + aacidCounter[9]*5500;
	if(e1!=0||e2!=0)
			printf("%d \n%d\n",e1,e2);
	else
			printf("As there are no Trp, Tyr or Cys in the region considered, your proteinshould not be visible by UV spectrophotometry.\n");



printf("Aliphatic Index ");
//Aliphatic index = X(Ala) + a * X(Val) + b * ( X(Ile) + X(Leu) )
aIndex = (aacidCounter[1]+a*aacidCounter[3]+b*(aacidCounter[5]+aacidCounter[4]))*10;

printf("%f \n",aIndex);




printf("\nGrand average of hydropathicity (GRAVY) ");

for(i=0;i<20;i++)
    GRAVYtotal = GRAVYtotal + ((float)aacidCounter[i]*GRAVYparam[i]);

GRAVY = GRAVYtotal/aacidCounterTotal;

printf("%f \n",GRAVY);



//Half Life

printf("The N-terminal of the sequence considered is %c ",seq[0]);
for(i=0;i<20;i++)if(seq[0]==aacid[i])printf("(%s)\n",aacidName[i]);
printf("Estimated Half life\n");
for(i=0;i<20;i++)
		if(seq[0]==aacid[i])
		{printf("Mammalian\t%s\nYeast\t%s\nE. coli\t%s\n",halfLife[i][0],halfLife[i][1],halfLife[i][2]);
		break;}


//Absorbance
//The absorbance (optical density) can be calculated using the following formula:
//                  Absorb(Prot) = E(Prot)/Molecular_weight

absorbance[0] = e1/molecularWeight;
absorbance[1] = e2/molecularWeight;
printf("\nAbsorbance 1 %f\nAbsorbance 2 %f\n",absorbance[0],absorbance[1]);
return 0;

}



