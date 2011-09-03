#include<iostream>
#include<string>
#include<algorithm>
using namespace std;


string Transcriptor(string a)
{
    int i;
    for(i=0;i<a.size();i++)    if(a[i]=='T') a[i]='U';
    return a;
}

int main()
{
    string a;
    cin>>a;
    a=Transcriptor(a);
    cout<<a<<endl;
    return 0;
}
