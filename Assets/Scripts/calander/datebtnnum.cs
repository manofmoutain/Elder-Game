using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class datebtnnum
{
    public int date = -1;
    public bool appeal = false;

    public datebtnnum() { }
    public datebtnnum(int date, bool appeal = false) {
        this.date = date;
        this.appeal = appeal;
    }
}
