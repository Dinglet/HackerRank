/*
Tries: Contacts
https://www.hackerrank.com/challenges/ctci-contacts/problem

The knowledge about the trie is acquired from ``演算法筆記 - String"
url: http://www.csie.ntnu.edu.tw/~u91029/String.html
*/
#include<iostream>
#include<map>
#include<string>

using namespace std;

class Trie
{
private:
    typedef struct TrieNode
    {
        map<char, TrieNode*> pNextLetter;
        int count;
        bool word;
        TrieNode()
        {
            count = 0;
            word = false;
        }
        ~TrieNode()
        {
            for(auto it = pNextLetter.begin(); it!=pNextLetter.end(); ++it)
                if(it->second) delete it->second;
        }
    } TrieNode;
public:
    void add(string str)
    {
        TrieNode *pNode = root;
        for(const char *s = str.c_str(); *s; s+=1)
        {
            if(! pNode->pNextLetter[*s])
                pNode->pNextLetter[*s] = new TrieNode;
            pNode = pNode->pNextLetter[*s];
        }

        if(pNode->word)
            return;
        pNode->word = true;

        pNode = root;
        for(const char *s = str.c_str(); *s; s+=1)
        {
            pNode->count += 1;
            pNode = pNode->pNextLetter[*s];
        }
        pNode->count += 1;
    }
    int countPrefix(string str)
    {
        TrieNode *pNode = root;
        const char *s = str.c_str();
        for(; *s; s+=1)
        {
            if(! pNode->pNextLetter[*s])
                return 0;
            pNode = pNode->pNextLetter[*s];
        }
        return *s ? 0 : pNode->count;
    }
    bool search(string str)
    {
        TrieNode *pNode = root;
        for(const char *s = str.c_str(); *s; s+=1)
        {
            if(! pNode->pNextLetter[*s])
                return false;
            pNode = pNode->pNextLetter[*s];
        }
        return pNode->word;
    }
    void traversal()
    {
        string str;
        traversal(root, str);
    }
private:
    TrieNode *root = new TrieNode;
    void traversal(TrieNode *pNode, string buffer)
    {
        if(!pNode) return;
        if(pNode->word)
            cout << buffer << "\n";
        buffer.resize(buffer.size()+1);
        for(auto it=pNode->pNextLetter.begin(); it!=pNode->pNextLetter.end(); ++it)
        {
            buffer.back() = it->first;
            traversal(pNode->pNextLetter[it->first], buffer);
        }
    }
};
int main()
{
    int n;
    string op;
    string contact;

    Trie contacts;
    
    cin >> n;
    for(int a0 = 0; a0 < n; a0++)
    {
        cin >> op >> contact;
        if(op.compare("add")==0)
            contacts.add(contact);
        if(op.compare("find")==0)
            cout << contacts.countPrefix(contact) << "\n";
    }
    return 0;
}
