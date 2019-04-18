(function()
{
function G(id)
{
    return document.getElementById(id)
}
function C(tg)
{
    return document.createElement(tg)
}
function CHI(n,v)
{
    var i=C("INPUT");
    i.type="hidden";
    i.name=n;
    i.value=v;
    return i
}
var S=G("sug"),I=G("kw"),F=document.f,SD,CS=null,c=-1,K=false,mouseOnSug=false;
var isIE=navigator.userAgent.indexOf("MSIE")!=-1&&!window.opera;
var isWebKit=(navigator.userAgent.indexOf("AppleWebKit/")>-1);
var isGecko=(navigator.userAgent.indexOf("Gecko")>-1)&&(navigator.userAgent.indexOf("KHTML")==-1);
var timer3=0;
function cs()
{
    if(isIE)
    {
        G("sugif").style.display="none"
    }
    S.style.display="none";
    timer3=0
}
function ct()
{
    var trs=T.rows;
    for(var i=0;i<trs.length;i++)
    {
        trs[i].className="ml"
    }
}
function clktr(j)
{
	return function()
	{
		cs();
		tj(j);
		clearTimeout(timer1);
		timer1=0;
		clearTimeout(timer2);
		timer2=0;
		setTimeout((function(inn)
		{
			return function()
			{
				sub(inn)
			}
		}
		)(this.cells[0].innerHTML),200)
	}
}
function sub(v)
{
    I.value=v;
    F.submit()
}
function tj(rsp)
{
    if(typeof (F.oq)=="undefined")
    {
        F.appendChild(CHI("oq",SD.q));
        if(typeof (F.f)!="undefined")
        {
            F.f.value=3
        }
        else
        {
            F.appendChild(CHI("f",3))
        }
        F.appendChild(CHI("rsp",rsp))
    }
    else
    {
        F.oq.value=SD.q;
        F.f.value=3;
        F.rsp.value=rsp
    }
}
function setSug()
{
    if(typeof (SD)!="object"||typeof (SD.s)=="undefined")
    {
        return
    }
    var tab=C("table");
    with(tab)
    {
        id="sug_t";
        style.width="100%";
        style.backgroundColor="#fff";
        cellSpacing=0;
        cellPadding=2;
        style.cursor="default"
    }
    var tb=C("tbody");
    tab.appendChild(tb);
    for(var i=0;i<SD.s.length;i++)
    {
        var tr=tb.insertRow(-1);
        tr.onmouseover=function()
        {
            ct();
            this.className="mo";
            mouseOnSug=true
        };
        tr.onmouseout=ct;
        tr.onmousedown=clktr(i);
        var td=tr.insertCell(-1);
        td.innerHTML=SD.s[i]
    }
    S.innerHTML="";
    S.appendChild(tab);
    S.style.width=(isIE?I.offsetWidth:I.offsetWidth-2)+"px";
    S.style.top=(isGecko?I.offsetHeight-1:I.offsetHeight)+"px";
    S.style.display="block";
    if(isIE)
    {
        var sug_if=G("sugif");
        with(sug_if.style)
        {
            display="";
            position="absolute";
            top=I.offsetHeight+"px";
            left="0px";
            width=S.offsetWidth+"px";
            height=tab.offsetHeight+"px"
        }
    }
    T=G("sug_t");
    c=-1;
    s3=""
}
function kd(e)
{
    e=e||window.event;
    K=false;
    var ctr;
    if(e.keyCode==13)
    {
        if(isIE)
        {
            e.returnValue=false
        }
        else
        {
            e.preventDefault()
        }
        if(c>=0)
        {
            tj(c)
        }
        F.submit();
        return
    }
    if(e.keyCode==38||e.keyCode==40)
    {
        mouseOnSug=false;
        if(S.style.display!="none")
        {
            var trs=T.rows;
            var l=trs.length;
            for(var i=0;i<l;i++)
            {
                if(trs[i].className=="mo")
                {
                    c=i;
                    break
                }
            }
            ct();
            var ctr;
            if(e.keyCode==38)
            {
                if(c==0)
                {
                    I.value=SD.q;
                    c=-1;
                    K=true
                }
                else
                {
                    if(c==-1)
                    {
                        c=l
                    }
                    ctr=trs[--c];
                    ctr.className="mo";
                    I.value=ctr.cells[0].innerHTML
                }
            }
            if(e.keyCode==40)
            {
                if(c==l-1)
                {
                    I.value=SD.q;
                    c=-1;
                    K=true
                }
                else
                {
                    ctr=trs[++c];
                    ctr.className="mo";
                    I.value=ctr.cells[0].innerHTML
                }
            }
            if(!isIE)
            {
                e.preventDefault()
            }
        }
    }
}
window.baidu=
{
    sug:function(data)
    {
        if(typeof (data)=="object"&&typeof (data.s)!="undefined"&&typeof (data.s[0])!="undefined")
        {
            SD=data;
            setSug()
        }
        else
        {
            cs();
            SD=
            {
            }
        }
    }
};
var s1="";
var s3=I.value;
var timer2=0;
function cb()
{
    var b=true;
    var bs=I.value;
    if(typeof (T)!="undefined"&&T!=null)
    {
        var trs=T.rows;
        for(var i=0;i<trs.length;i++)
        {
            if(trs[i].className=="mo")
            {
                if(bs==trs[i].cells[0].innerHTML&&!mouseOnSug)
                {
                    b=false
                }
            }
        }
    }
    if(b&&!K)
    {
        if(CS)
        {
            document.body.removeChild(CS)
        }
        CS=C("script");
        CS.src="http://suggestion.baidu.com/su?wd="+encodeURIComponent(I.value)+"&t="+(new Date()).getTime();
        document.body.appendChild(CS)
    }
}
function f()
{
    var s2=I.value;
    if(s2==s1&&s2!=""&&s2!=s3)
    {
        if(timer2==0)
        {
            timer2=setTimeout(cb,100)
        }
    }
    else
    {
        clearTimeout(timer2);
        timer2=0;
        s1=s2;
        if(s2=="")
        {
            cs()
        }
    }
}
var timer1=setInterval(f,10);
I.oncontextmenu=function()
{
    K=false
};
I.onkeydown=kd;
var isClkSug=false;
I.onblur=function(e)
{
    if(!isClkSug)
    {
        if(timer3==0)
        {
            timer3=setTimeout(cs,200)
        }
    }
    isClkSug=false
};
document.onmousedown=function(e)
{
    e=e||window.event;
    var elm=e.target||e.srcElement;
    if(elm==I)
    {
        return
    }
    while(elm=elm.parentNode)
    {
        if(elm==S||elm==I)
        {
            isClkSug=true;
            return
        }
    }
    if(timer3==0)
    {
        timer3=setTimeout(cs,200)
    }
};
window.onresize=function()
{
    if(typeof (timer3)!="undefined"&&timer3!=0)
    {
        clearTimeout(timer3)
    }
    resetSuggestion()
};
S.style.zIndex=200;
if(isIE)
{
    var sug_if=C("IFRAME");
    sug_if.src="javascript:void(0)";
    sug_if.id="sugif";
    with(sug_if.style)
    {
        display="none";
        position="absolute"
    }
    S.parentNode.insertBefore(sug_if,S)
}
function resetSuggestion()
{
    if(S.style.display!="none")
    {
setTimeout(function()
{
    cs();
    if(SD!=null)
    {
        setSug(SD);
        I.focus()
    }
}
,100)
}
}
document.onkeydown=function(e)
{
if(isGecko)
{
e=e||window.event;
if(e.ctrlKey)
{
    if(e.keyCode==61||e.keyCode==107||e.keyCode==109||e.keyCode==96||e.keyCode==48)
    {
        resetSuggestion()
    }
}
}
}
}
)();
