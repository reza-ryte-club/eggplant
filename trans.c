#include<stdio.h>
char aacidDet(char *str);

int main(){

char aminoAcid;
int count2,count3=0;
char seq[90];
int i;
int count = 0;
char str1[4];
int j=0;

char aacid[16][4][3]= { "TTT","TCT","TAT","TGT",
			"TTC","TCC","TAC","TGC",
			"TTA","TCA","TAA","TGA",
			"TTG","TCG","TAG","TGG",


			"CTT","CCT","CAT","CGT",
			"CTC","CCC","CAC","CGC",
			"CTA","CCA","CAA","CGA",
			"CTG","CCG","CAG","CGG",


			"ATT","ACT","AAT","AGT",
			"ATC","ACC","AAC","AGC",
			"ATA","ACA","AAA","AGA",
			"ATG","ACG","AAG","AGG",


			"GTT","GCT","GAT","GGT",
			"GTC","GCC","GAC","GGC",
			"GTA","GCA","GAA","GGA",
			"GTG","GCG","GAG","GGG",
			};


printf("Enter the sequence \n");

for(i = 0;i<90;i++)
{
scanf("%c",&seq[i]);
count3++;
if(seq[i]=='\n')
break;
}



        for(i=0;i<90;i++)
        {
			if(seq[i]=='\n') break;
			printf ("%c",seq[i]);
			count++;
			if(count%3==0)printf("\n");

        }


printf("\n");
count2=count;count=0;
for(i=0;i<count2;i++)
			{
			if(seq[i]=='\n') break;
			str1[j]=seq[i];j++;
			count++;
					if(count%3==0){j=0;str1[3]='\0';
							aminoAcid = aacidDet(str1);
							//printf("[%s:%c]",str1,aminoAcid);
							if (aminoAcid=='Z') printf(" stop ");
							else if (aminoAcid=='B') printf(" \n");
							else printf("%c",aminoAcid);
							}

			}



    printf("\n");

    return 0;
}



char aacidDet(char *str){

			if(!strcmp(str,"TTT")) return 'F';///if string is same strcmp returns 0
			else if	(!strcmp(str,"TTC")) return 'F';
			else if	(!strcmp(str,"TTA")) return 'L';
			else if	(!strcmp(str,"TTG")) return 'L';
			else if	(!strcmp(str,"CTT")) return 'L';
			else if	(!strcmp(str,"CTC")) return 'L';
			else if	(!strcmp(str,"CTA")) return 'L';
			else if	(!strcmp(str,"CTG")) return 'L';
			else if	(!strcmp(str,"ATT")) return 'I';
			else if	(!strcmp(str,"ATC")) return 'I';
			else if	(!strcmp(str,"ATA")) return 'I';
			else if	(!strcmp(str,"ATG")) return 'M';
			else if	(!strcmp(str,"GTT")) return 'V';
			else if	(!strcmp(str,"GTC")) return 'V';
			else if	(!strcmp(str,"GTA")) return 'V';
			else if	(!strcmp(str,"GTG")) return 'V';
			else if	(!strcmp(str,"TCT")) return 'S';
			else if	(!strcmp(str,"TCC")) return 'S';
			else if	(!strcmp(str,"TCA")) return 'S';
			else if	(!strcmp(str,"TCG")) return 'S';
			else if	(!strcmp(str,"CCT")) return 'P';
			else if	(!strcmp(str,"CCC")) return 'P';
			else if	(!strcmp(str,"CCA")) return 'P';
			else if	(!strcmp(str,"CCG")) return 'P';
			else if	(!strcmp(str,"ACT")) return 'T';
			else if	(!strcmp(str,"ACC")) return 'T';
			else if	(!strcmp(str,"ACA")) return 'T';
			else if	(!strcmp(str,"ACG")) return 'T';
			else if	(!strcmp(str,"GCT")) return 'A';
			else if	(!strcmp(str,"GCC")) return 'A';
			else if	(!strcmp(str,"GCA")) return 'A';
			else if	(!strcmp(str,"GCG")) return 'A';
			else if	(!strcmp(str,"TAT")) return 'Y';
			else if	(!strcmp(str,"TAC")) return 'Y';
			else if	(!strcmp(str,"TAA")) return 'Z';// z MEANS STOP
			else if	(!strcmp(str,"TAG")) return 'Z';

			else if	(!strcmp(str,"CAT")) return 'H';
			else if	(!strcmp(str,"CAC")) return 'H';

			else if	(!strcmp(str,"CAA")) return 'Q';
			else if	(!strcmp(str,"CAG")) return 'Q';
			else if	(!strcmp(str,"AAT")) return 'N';
			else if	(!strcmp(str,"AAC")) return 'N';
			else if	(!strcmp(str,"AAA")) return 'K';
			else if	(!strcmp(str,"AAG")) return 'K';



			else if	(!strcmp(str,"GAT")) return 'D';
			else if	(!strcmp(str,"GAC")) return 'D';
			else if	(!strcmp(str,"GAA")) return 'E';
			else if	(!strcmp(str,"GAG")) return 'E';


			else if	(!strcmp(str,"TGT")) return 'C';
			else if	(!strcmp(str,"TGC")) return 'C';
			else if	(!strcmp(str,"TGA")) return 'Z';
			else if	(!strcmp(str,"TGG")) return 'W';

			else if	(!strcmp(str,"CGT")) return 'R';
			else if	(!strcmp(str,"CGC")) return 'R';
			else if	(!strcmp(str,"CGA")) return 'R';
			else if	(!strcmp(str,"CGG")) return 'R';



			else if	(!strcmp(str,"AGT")) return 'S';
			else if	(!strcmp(str,"AGC")) return 'S';
			else if	(!strcmp(str,"AGA")) return 'R';
			else if	(!strcmp(str,"AGG")) return 'R';


			else if	(!strcmp(str,"GGT")) return 'G';
			else if	(!strcmp(str,"GGC")) return 'G';
			else if	(!strcmp(str,"GGA")) return 'G';
			else if	(!strcmp(str,"GGG")) return 'G';


			else return 'B';/// B means invalid

			}

