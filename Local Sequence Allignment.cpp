#include<iostream>
#include<sstream>
#include<string>
#include<cstdlib>
#include<vector>
#include<map>
#include<queue>
#include<stack>
#include<cctype>
#include<set>
#include<bitset>
#include<algorithm>
#include<list>
#include<utility>
#include<functional>
#include <deque>
#include <numeric>
#include <iomanip>
#include <cstdio>
#include <cstring>
#include <ctime>


#include<cmath>
#include<math.h>

#include<stdio.h>
#include<string.h>
#include<stdlib.h>
#include<ctype.h>

using namespace std;

#define deb(a)      cout<<" -> "<<#a<<"  "<<a<<endl;
#define oo          (1<<30)
#define ERR         1e-5
#define PRE         1e-8
#define popcount(a) (__builtin_popcount(a))
#define SZ(a)       ((int)a.size())
#define X           first
#define Y           second
#define PB          push_back
#define LL          long long
#define MP          make_pair
#define ISS         istringstream
#define OSS         ostringstream
#define SS          stringstream
#define VS          vector<string>
#define VI          vector<int>
#define VD          vector<double>
#define VLL         vector<long long>
#define IT          ::iterator
#define SI          set<int>
#define mem(a,b)    memset(a,b,sizeof(a))
#define memc(a,b)   memcpy(a,b,sizeof(b))
#define accu(a,b,c) accumulate((a),(b),(c))
#define fi(i,a,b)   for(i=a;i<b;i++)
#define fd(i,a,b)   for(i=a;i>b;i--)
#define fii(a,b)    for(i=a;i<b;i++)
#define fdi(a,b)    for(i=a;i>b;i--)
#define fij(a,b)    for(j=a;j<b;j++)
#define fdj(a,b)    for(j=a;j>b;j--)
#define fik(a,b)    for(k=a;k<b;k++)
#define fdk(a,b)    for(k=a;k>b;k--)
#define fil(a,b)    for(l=a;l<b;l++)
#define fdl(a,b)    for(l=a;l>b;l--)
#define ri(i,a)     for(i=0;i<a;i++)
#define rd(i,a)     for(i=a;i>-1;i--)
#define rii(a)      for(i=0;i<a;i++)
#define rdi(a)      for(i=a;i>-1;i--)
#define rij(a)      for(j=0;j<a;j++)
#define rdj(a)      for(j=a;j>-1;j--)
#define rik(a)      for(k=0;k<a;k++)
#define rdk(a)      for(k=a;k>-1;k--)
#define ril(a)      for(l=0;l<a;l++)
#define rdl(a)      for(l=a;i>-1;l--)

#define fore(e,x) for(__typeof(x.begin()) e=x.begin();e!=x.end();++e)

#define EQ(a,b)     (fabs(a-b)<ERR)
#define all(a)      (a).begin(),(a).end()
#define CROSS(a,b,c,d)  ((b.x-a.x)*(d.y-c.y)-(d.x-c.x)*(b.y-a.y))
#define sqr(a)      ((a)*(a))
#define p2(a)       (1LL<<a)
#define INC(a,b,c)   (b<=a&&a<=c)

//const double pi=2*acos(0.);

template<class TT>TT abs(TT a){if(a<0)  return -a;return a;}
template<class ZZ>ZZ max(ZZ a,ZZ b,ZZ c){return max(a,max(b,c));}
template<class ZZ>ZZ min(ZZ a,ZZ b,ZZ c){return min(a,min(b,c));}

//typedef pair< , > pi;
typedef struct {int x,y;    void print(){printf("%d %d\n",x,y);}}P;
//bool operator < (const P &a,const P &b){    return (a.x!=b.x?a.x<b.x:a.y<b.y);}
//bool com(P a,P b){return(a.x!=b.x?a.x<b.x:a.y<b.y);}
//struct pq{int n,w;  bool operator<(const pq &b)const{return w>b.w;}};


const int inf = p2(30);
int mm[1001][1001];
int CS,DS,IS,MS;
char v[1002];
char w[1002];
char path[1001][1001];
string s1,s2;
int delta[150][150],mxscore,mr,mc;

int go(int r,int c)
{
    if(r<0||c<0)    return -inf;
    if(!r&&!c )     return  0;

    int  &re=mm[r][c];
    char &p=path[r][c];
    if(p)   return re;

    re=0;

    ///Change
    if(re<go(r-1,c-1)+((v[r]==w[c])?MS:CS))
    {
        re=go(r-1,c-1)+((v[r]==w[c])?MS:CS);
        p='c';
    }

    ///Deletetion
    if(re<go(r-1,c)+DS)
    {
        re=go(r-1,c)+DS;
        p='d';
    }

    ///Insertion
    if(re<go(r,c-1)+IS)
    {
        re=go(r,c-1)+DS;
        p='i';
    }

    if(mxscore<re)
    {
        mxscore=re;
        mr=r;
        mc=c;
    }

    return re;
}

//void Print_Path(int r,int c)
//{
//   // if(go(r,c)==0)  return;
//    if(!r && !c)  return;
//
//    if(path[r][c]=='i')
//    {
//        Print_Path(r,c-1);
//        s1+='_';
//        s2+=w[c];
//    }
//    else if(path[r][c]=='d')
//    {
//        Print_Path(r-1,c);
//        s1+=v[r];
//        s2+='_';
//    }
//    else
//    {
//        Print_Path(r-1,c-1);
//        s1+=v[r];
//        s2+=w[c];
//    }
//    s1+=' ';
//    s2+=' ';
//    return ;
//}


void Best_Path(int r,int c)
{
    if(go(r,c)==0)  return;
    //if(!r && !c)  return;

    if(path[r][c]=='i')
    {
        Best_Path(r,c-1);
        s1+='_';
        s2+=w[c];
    }
    else if(path[r][c]=='d')
    {
        Best_Path(r-1,c);
        s1+=v[r];
        s2+='_';
    }
    else
    {
        Best_Path(r-1,c-1);
        s1+=v[r];
        s2+=w[c];
    }
    printf("%d -> %d %d\n",mxscore--,r,c);
    s1+=' ';
    s2+=' ';
    return ;
}


int main()
{
    //freopen("in.in","r",stdin);
    //freopen("ou.in","w",stdout);
     //ios_base::sync_with_stdio(false);
    int tks,ks=1,cost,lv,lw,score;

    IS=DS=-1;
    CS=1;
    MS=-3;

    while(gets(v+1)&&gets(w+1))
    {
        mem(mm,-1);
        mem(path,0);

        mxscore=-1;mr=mc=0;

        lv = strlen(v+1);
        lw = strlen(w+1);
        deb(lv);
        deb(lw);

        ///Find_Score
        score = go(lv,lw);

        cout<<"Score : "<<mxscore<<endl;
        for(int i=0;i<=lv;i++)
        {
            for(int j=0;j<=lw;j++)  printf("%4d",mm[i][j]);
            cout<<endl;
        }

//        s1=s2="";
//        ///Generating the alignment.
//        Print_Path(lv,lw);
//        ///Comparing the sequnces.
//        cout<<s1<<endl<<s2<<endl;

        s1=s2="";
        Best_Path(mr,mc);
        cout<<s1<<endl<<s2<<endl;
    }

    return 0;
}


