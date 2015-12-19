using System.Collections;
using System.IO;
using System.Collections.Generic;
using System;
using UnityEngine;

public class CSVReader
{
    #region poi
    string p1_1 = "left,front,right,front,5,1\nleft,front,right,front,5,1\nleft,front,right,back,5,1\nleft,front,right,back,5,1\nleft,back,right,back,5,1\nleft,back,right,back,5,1\nleft,front,right,back,5,1\nleft,front,right,back,5,1\nleft,front,right,front,5,1\nleft,front,right,front,5,1\nleft,front,right,back,5,1\nleft,front,right,back,5,1\nleft,back,right,back,5,1\nleft,back,right,back,5,1\n";
    string p1_2 = "right,back,left,back,5,1\nright,back,left,back,5,1\nright,front,left,back,5,1\nright,front,left,back,5,1\nright,back,left,back,5,1\nright,back,left,back,5,1\nright,back,left,front,5,1\nright,back,left,front,5,1\nright,front,left,front,5,1\nright,front,left,front,5,1\nright,back,left,back,5,1\nright,back,left,back,5,1\nfront,right,5,1\nfront,right,5,1\nfront,right,5,1\nfront,left,5,1\nfront,left,5,1\nfront,left,5,1\n";
    string p1_3 = "back,right,5,1\nback,right,5,1\nfront,right,back,right,5,1\nfront,left,back,left,5,1\nback,left,5,1\nback,left,5,1\nback,right,5,1\nback,left,5,1\nleft,front,5,1\nright,front,5,1\nleft,back,5,1\nright,back,5,1\nfront,right,5,1\nfront,left,5,1\nfront,right,5,1\nfront,left,5,1\nfront,right,5,1\nfront,left,5,1\nfront,right,5,1\nfront,left,5,1\n";
    string p2_2 = "front,back,left,3,1\nfront,back,right,3,1\nfront,back,left,3,1\nfront,back,3,1\nfront,back,right,3,1\nfront,back,left,3,1\nfront,back,3,1\nfront,back,3,1\nfront,back,3,1\nfront,back,right,3,1\nfront,back,left,right,3,1\nfront,back,left,right,3,1\nfront,back,right,3,1\nfront,back,3,1\nfront,back,right,3,1\nfront,back,left,3,1\nfront,back,3,1\nfront,back,right,3,1\nfront,back,right,left,3,1\nfront,back,left,3,1\nfront,back,3,1\nfront,back,3,1\nfront,back,3,1\nfront,back,right,3,1\nfront,back,left,3,1\nfront,back,left,right,3,1\nback,front,right,left,3,1\nback,front,right,3,1\nback,front,left,3,1\nback,front,right,3,1\nback,front,3,1\nback,front,3,1\nback,front,3,1\nback,front,left,3,1\nback,front,3,1\nback,front,3,1\nback,front,3,1\nback,front,right,3,1\nback,front,left,3,1\nback,front,left,right,3,1\nfront,back,right,left,3,1\nback,front,left,3,1\nback,front,right,3,1\nback,front,left,3,1\nback,front,3,1\nback,front,right,3,1\nback,front,left,3,1\nback,front,3,1\nback,front,3,1\nback,front,3,1\nback,front,right,3,1";
    #endregion
    #region enemy
    string e1_1 = "melee,0,1\nmelee,1,0\nranged,2\nranged,3\nmelee,4,6,8\nmelee,5,7,9\nranged,6\nranged,7\nmelee,8,6,4\nmelee,9,7,5\nranged,10\nranged,11\nmelee,12,13\nmelee,13,12";
    string e1_2 = "ranged,0\nranged,1\nmelee,2,0,1,3\nmelee,3,1,0,2\nranged,4\nranged,5\nranged,6\nranged,7\nranged,8\nranged,9\nmelee,10,6,4\nmelee,11,7,5\nmelee,12,10,11,4,5\nmelee,13,6\nmelee,14,10,4\nmelee,15,11,5\nmelee,16,7\nmelee,17,5,4,11,10\n";
    string e1_3 = "melee,0,14\nranged,1\nmelee,2,3\nmelee,3,2\nranged,4\nmelee,5,15\nmelee,6,12,13,7\nmelee,7,6,12,13\nranged,8\nranged,9\nranged,10\nranged,11\nmelee,12,13,7,6\nmelee,13,7,6,12\nmelee,14,0\nmelee,15,5\nramged,16\nranged,17\nmelee,18,19\nmelee,19,18\n";
    string e2_2 = "melee,0,13\nmelee,1,14\nmelee,2,15\nmelee,16,3\nmelee,4,17\nmelee,5,19\nmelee,20,6\nmelee,7,21\nmelee,22,8\nmelee,9,23\nmelee,50,37\nmelee,36,45\nmelee,48,35\nmelee,34,47\nmelee,46,33\nmelee,45,32\nmelee,31,44\nmelee,43,30\nmelee,42,29\nmelee,41,28\nranged,10\nranged,11\nranged,12\nranged,18\nranged,24\nranged,25\nranged,26\nranged,27\nranged,38\nranged,39\nranged,40";
    #endregion
    StringReader csv;

    public CSVReader(char type, string level)
    {
        string t = "";
        if(level == "Level1-1" || level == "Level1-6")
            if(type == 'e')
                t = e1_1;
            else
                t = p1_1;
        else if(level == "Level1-2" || level == "Level1-4")
            if(type == 'e')
                t = e1_2;
            else
                t = p1_2;
        else if(level == "Level1-3")
            if(type == 'e')
                t = e1_3;
            else
                t = p1_3;
        else if(level == "Level2-2" || level == "Level2-1")
            if(type == 'e')
                t = e2_2;
            else
                t = p2_2;
        Debug.Log(t);
        csv = new StringReader(t);
    }

    public List<string[]> Read()
    {
        List<string[]> file = new List<string[]>();
        string line;
        while((line = csv.ReadLine()) != null)
        {
            file.Add(line.Split(','));
        }
        return file;
    }
}
