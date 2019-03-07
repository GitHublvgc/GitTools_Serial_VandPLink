using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;


namespace VandP_Serial
{
    public class DataConvert
    {
        /// <Summary> 将按UTF8格式编码的字节流编码成字符串</Summary>
        /// <Remarks> by: wYTw@163.com or wwYTww@Hotmail.com      Date: 2008-07-08 13:32:30</Remarks>
        /// <param name="bBytes">UTF8格式的字节数组</param>
       /// <returns>将UTF8格式的字节数组转换为字符串的值</returns>
        public static string Byte2String(byte[] bBytes)
        {
            StringBuilder sb = new StringBuilder();
            int i, iLen = bBytes.Length;
            char cChar=(char)0;
            byte bCnt = (byte)0;
            for (i = 0; i < iLen; i++)
            { //"d我爱你！黑牛豆奶wers4w";
                if((bBytes[i]>=(byte)0x20)&&(bBytes[i]<=(byte)0x7F))
                {//可显示ASCII
                    cChar = (char)bBytes[i];
                    sb.Append(cChar.ToString());
                }
                else
                {//不可显示的ASCII
                    if (bBytes[i] >= (byte)0x80)
                    {
                        bCnt++;
                        if (bCnt > 2)
                        {
                            bCnt = 0;
                            string str = System.Text.Encoding.UTF8.GetString(bBytes, i-2, 3);
                            sb.Append(str);
                        }
                    }
                    else
                    { 
                        sb.Append(bBytes[i].ToString("X2")+" ");
                    }
                }
            }
            //
            return sb.ToString();
        }
        /// <Summary> 将按UTF8格式编码的bBytes[],以iStartIndex开始，长度为iLen的字节流编码成字符串</Summary>
        /// <Remarks> by: wYTw@163.com or wwYTww@Hotmail.com      Date: 2008-07-08 14:51:30</Remarks>
        /// <param name="bBytes">UTF8格式的字节流</param>
        /// <param name="iStartIndex">开始转化的起始位置</param>
        /// <param name="iLen">转化字节流长度</param>
        /// <returns>转换后的字节流的字符串标识值</returns>
        public static string Byte2String(byte[] bBytes, int iStartIndex, int iLen)
        {
            StringBuilder sb = new StringBuilder();
            int i = iStartIndex;
            char cChar=(char)0;
            byte bCnt = (byte)0;
            for (i = iStartIndex; i < iStartIndex + iLen; i++)
            { //"d我爱你！黑牛豆奶wers4w";
                if ((bBytes[i] >= (byte)0x20) && (bBytes[i] <= (byte)0x7F))
                {//可显示ASCII
                    cChar = (char)bBytes[i];
                    sb.Append(cChar.ToString());
                }
                else
                {//不可显示的ASCII
                    if (bBytes[i] >= (byte)0x80)
                    {
                        bCnt++;
                        if (bCnt > 2)
                        {
                            bCnt = 0;
                            string str = System.Text.Encoding.UTF8.GetString(bBytes, i-2, 3);
                            sb.Append(str);
                        }
                    }
                    else
                    { 
                        sb.Append(bBytes[i].ToString("X2")+" ");
                    }
                }
            }
            //
            return sb.ToString();
        }
       
        public static string Bytes2HexString(byte[] bBuf, int iIndex, int iBufLen)
        {
            StringBuilder strB = new StringBuilder();
            string strTmp;
            int i = 0;
            i = bBuf.Length;
            for (i = iIndex; i < iIndex + iBufLen; i++)
            {
                strB.Append(string.Format("{0:X02} ", (byte)bBuf[i]));
            }
            //
            strTmp = strB.ToString();
            return strTmp;
        }
        /// <summary>
        /// 字节数组转16进制字符串
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static string byteToHexStr(byte[] bytes)
        {
            string returnStr = "";
            if (bytes != null)
            {
                for (int i = 0; i < bytes.Length; i++)
                {
                    returnStr += bytes[i].ToString("X2");
                }
            }
            return returnStr;
        }
        public static string Bytes2HexStringNOSpace(byte[] bBuf, int iIndex, int iBufLen)
        {
            StringBuilder strB = new StringBuilder();
            string strTmp;
            int i = 0;
            i = bBuf.Length;
            for (i = iIndex; i < iIndex + iBufLen; i++)
            {
                strB.Append(string.Format("{0:X02}", (byte)bBuf[i]));
            }
            //
            strTmp = strB.ToString();
            return strTmp;
        }
        public static string Bytes2HexStringNOSpaceReverse(byte[] bBuf, int iIndex, int iBufLen)
        {
            string strB = "";
            string strTmp;
            int i = 0;
            i = bBuf.Length;
            for (i = iIndex; i < iIndex + iBufLen; i++)
            {
                //strB.Append(string.Format("{0:X02}", (byte)bBuf[i]));
                strB=string.Format("{0:X02}", (byte)bBuf[i])+strB;
            }
            
            return strB;
            
        }

        public static string Byte2StringHexMix(byte[] bBytes, int iStartIndex, int iLen)
        {
            StringBuilder sb = new StringBuilder();
            int i = iStartIndex;
            for (i = iStartIndex; i < iStartIndex + iLen; i++)
            { //"d我爱你！黑牛豆奶wers4w";
                if ((bBytes[i] >= (byte)0x20) && (bBytes[i] <= (byte)0x7F))
                {//可显示的ASCII
                    //sb.Append(bBytes[i].ToString("X2"));
                    sb.Append(((char)bBytes[i]).ToString());//可显示ASCII
                }
                else
                {//不可显示的ASCII或汉字
                    bool isHZ = false;
                    if ((bBytes[i] >= (byte)0x80) && (i + 2 < iStartIndex + iLen) && (bBytes[i + 1] >= (byte)0x80) && (bBytes[i + 2] >= (byte)0x80))
                    {//处理了汉字的情况 by: wYTw@163.com or wwYTww@Hotmail.com      Date: 2009-01-07 16:42:39
                        string str = System.Text.Encoding.UTF8.GetString(bBytes, i, 3);
                        if (str != "���")
                        {
                            isHZ = true;
                            sb.Append(str);
                            i+=2;
                        }
                    }
                    if (!isHZ)
                    {
                        if ((sb.Length > 0) && (sb[sb.Length - 1] != ' '))
                            sb.Append(" ");
                        sb.Append(bBytes[i].ToString("X2")+" ");
                    }
                    //sb.Append(" ");
                }
                //
            }
            
            return sb.ToString();
        }

        /// <summary>
        /// 将秒转化为"(天-)时:分:秒"的格式
        /// </summary>
        /// <param name="iSeconds">秒</param>
        /// <returns>将秒转换后"(天-)时:分:秒"的格式</returns>
        public static string fnSecond2DateTimeFmt(int iSeconds)
        {
            string strRet = "";
            int iD = iSeconds / 86400;// (24 * 3600);
            if (iD > 0)
                iSeconds -= iD * 86400;//一天内的秒数
            int iH = iSeconds / 3600;//Hour
            iSeconds -= iH * 3600;
            int iM = iSeconds / 60;//Minute;
            iSeconds -= iM * 60;
            //
            if (iD > 0)
                strRet = string.Format("{0}-{1}:{2}:{3}", iD.ToString("00"), iH.ToString("00"), iM.ToString("00"), iSeconds.ToString("00"));
            else
                strRet = string.Format("{0}:{1}:{2}", iH.ToString("00"), iM.ToString("00"), iSeconds.ToString("00"));
            //
            return strRet;
 
        }
        /// <summary>
        /// 将"(天-)时:分:秒"的格式转化为秒
        /// </summary>
        /// <param name="strTimeFmt">"(天-)时:分:秒"的格式表示的时间</param>
        /// <returns>将"(天-)时:分:秒"的格式转换成秒返回</returns>
        public static int fnSecond2DateTimeFmt(string strTimeFmt)
        {
            int iSec = 0;
            try
            {
                string strTmp = "";
                string[] strs = strTimeFmt.Split(new char[] { ':', ' ', '-', ';', ',' }, StringSplitOptions.RemoveEmptyEntries);
                int iD = 0, iH = 0, iM = 0, iS = 0;
                int iLen = strs.Length;
                switch (iLen)
                {
                    default:
                    case 4:
                        iD = DataConvert.GetIntAtStringLeft(strs[0].Trim(), ref strTmp);
                        iH = DataConvert.GetIntAtStringLeft(strs[1].Trim(), ref strTmp);
                        iM = DataConvert.GetIntAtStringLeft(strs[2].Trim(), ref strTmp);
                        iS = DataConvert.GetIntAtStringLeft(strs[3].Trim(), ref strTmp);
                        iS += iD * 24 * 3600;
                        break;
                    case 3:
                        iH = DataConvert.GetIntAtStringLeft(strs[0].Trim(), ref strTmp);
                        iM = DataConvert.GetIntAtStringLeft(strs[1].Trim(), ref strTmp);
                        iS = DataConvert.GetIntAtStringLeft(strs[2].Trim(), ref strTmp);
                        break;
                    case 2:
                        iM = DataConvert.GetIntAtStringLeft(strs[0].Trim(), ref strTmp);
                        iS = DataConvert.GetIntAtStringLeft(strs[1].Trim(), ref strTmp);
                        break;
                    case 1:
                        iS = DataConvert.GetIntAtStringLeft(strs[0].Trim(), ref strTmp);
                        break;
                }
                iSec += (iH * 3600 + iM * 60 + iS);
            }
            catch { }
            //
            return iSec;
        }
        /// <Summary> 将指定的字符串按UTF8的格式编码成字节格式</Summary>
        /// <Remarks> by: wYTw@163.com or wwYTww@Hotmail.com      Date: 2008-07-8 12:50:46</Remarks>
        /// <param name="strMsg">待转换的字符串</param>
        /// <returns>字符串转换后的UTF8编码的字节数组</returns>
        public static byte[] String2Bytes(string strMsg)
        {
            return System.Text.Encoding.UTF8.GetBytes(strMsg);
        }

        /// <summary>
        /// 十六进制字符串转化成byte数组
        /// (2010-11-3 by lawyer)
        /// </summary>
        /// <param name="str">输入十六进制字符串,每两个字符转化成一个byte,遇到不能转化的提前终止</param>
        /// <returns></returns>
        public static byte[] HEXString2Bytes(string input)
        {
            input = input.Trim().ToUpper();
            byte[] result = new byte[(input.Length + 1) / 2];

            int iPtr = 0; bool bCouple = true; byte b = 0;
            foreach (char c in input)
            {
                //首先验证范围
                if ((c >= (char)'0' && c <= (char)'9') || (c >= (char)'A' && c <= (char)'F'))
                {
                    b = byte.Parse(c.ToString(), System.Globalization.NumberStyles.HexNumber);
                    if (bCouple)
                        b *= (byte)0x10;
                    result[iPtr] += b;
                    bCouple = !bCouple;

                    if (bCouple)
                        iPtr++;
                }
                else if (c == ' ')
                    continue;
                else
                    break;
            }

            return GetPartData(result, 0, iPtr);
        }
        /// <summary>
        /// 获取byte数组的部分
        /// (2010-11-3 by lawyer)
        /// </summary>
        /// <param name="input"></param>
        /// <param name="iStart"></param>
        /// <param name="iLen"></param>
        /// <returns></returns>
        public static byte[] GetPartData(byte[] input, int iStart, int iLen)
        {
            //起始长度直接超出范围了
            if (input.Length < iStart)
                return new byte[] { };

            //从0开始。。。
            if (iStart == 0 && iLen > input.Length)
                return input.Clone() as byte[];

            int iRealLen = iLen;
            if (iStart + iLen > input.Length)
                iRealLen = input.Length - iStart;

            byte[] result = new byte[iRealLen];

            for (int i = 0; i < iRealLen; i++)
                result[i] = input[i + iStart];

            return result;
        }



        //public static byte[] String2Hex(string strData)
        //{
        //    strData = strData.ToUpper();
        //    byte[] bData = new byte[strData.Length];
        //    char cChar;
        //    for (int i = 0; i < strData.Length; i++)
        //    {
        //        cChar = strData[i];
        //        if (((cChar >= '0') && (cChar <= '9')) || ((cChar >= 'A') && (cChar <= 'F')))
        //        { 
        //        }
               
        //    }
        //    //
        //    return bData;
        //}

        /// <summary>
        /// 根据dataType确定该类型是否是数字类型
        /// </summary>
        /// <param name="dataType">要检查的类型</param>
        /// <returns>true:是数字类型,false:非数字类型</returns>
        public static bool IsNumericType(Type dataType)
        {
            switch (Type.GetTypeCode(dataType))
            {
                case TypeCode.Byte:
                case TypeCode.SByte:
                case TypeCode.Decimal:
                case TypeCode.Double:
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Int64:
                case TypeCode.Single:
                case TypeCode.UInt16:
                case TypeCode.UInt32:
                case TypeCode.UInt64:
                    return true;
                default:
                    return false;
            }
        }


        public static byte[] HexString2Bytes(string strData, char cSplit)
        {
            string strTmp;
            byte[] bSends = null;
            try
            {
                string[] strSends = strData.Trim().Split(new char[] { ' ', ',', cSplit },  StringSplitOptions.RemoveEmptyEntries);
                bSends = new byte[strSends.Length];
                for (int i = 0; i < strSends.Length; i++)
                {
                    if (strSends[i].Length > 2)
                        strTmp = strSends[i].Substring(0, 2);
                    else
                        strTmp = strSends[i];
                    bSends[i] = Convert.ToByte(strTmp, 16);
                }
            }
            catch (Exception exc)
            {
                strTmp = exc.Message;
                bSends = new byte[0];
            }
            //
            return bSends;
        }

        #region 为兼容以前的程序
        public static string GetFloatStringAtLeft(string strData, ref string strRemanent)
        {
            return fnGetFloatStringAtLeft(strData, ref strRemanent);
        }
        public static string GetFloatStringAtRight(string strData, ref string strRemanent)
        {
            return fnGetFloatStringAtRight(strData, ref strRemanent);
        }
        public static string GetIntStringAtLeft(string strData, ref string strRemanent)
        {
            return fnGetIntStringAtLeft(strData, ref strRemanent);
        }
        public static string GetIntStringAtRight(string strData, ref string strRemanent)
        {
            return fnGetIntStringAtRight(strData, ref strRemanent);
        }
        #endregion 
        public static string fnGetFloatStringAtLeft(string strData, ref string strRemanent)
        {
            string strLeftDigital = "0";
            strRemanent = "";
            try
            {
                strData = strData.Trim();
                int i;
                for (i = 0; i < strData.Length; i++)
                {
                    if (!char.IsDigit(strData[i]) && (strData[i] != '+') && (strData[i] != '-') && (strData[i] != '.'))
                        break;
                }
                if (i == strData.Length)
                {//OK, 整个都是 
                    strLeftDigital = strData;
                }
                else
                {
                    strLeftDigital = strData.Substring(0, i);
                    strRemanent = strData.Substring(i, strData.Length - i);
                }
            }
            catch { }
            //
            return strLeftDigital;
        }
        public static string fnGetFloatStringAtRight(string strData, ref string strRemanent)
        {
            string strRightDigital = "0";
            strRemanent = "";
            try
            {
                strData = strData.Trim();
                int i = strData.Length;
                while (--i >= 0)
                {
                    if (!char.IsDigit(strData[i]) && (strData[i] != '+') && (strData[i] != '-') && (strData[i] != '.'))
                        break;
                }
                if (i < 0)
                {//OK, 整个都是
                    strRightDigital = strData;
                }
                else
                {
                    strRemanent = strData.Substring(0, i);
                    strRightDigital = strData.Substring(i, strData.Length - i);
                }
            }
            catch { }
            //
            return strRightDigital;
        }
        public static string fnGetIntStringAtLeft(string strData, ref string strRemanent)
        {
            string strLeftDigital = "0";
            strRemanent = "";
            try
            {
                strData = strData.Trim();
                int i;
                for (i = 0; i < strData.Length; i++)
                {
                    if (!char.IsDigit(strData[i]) && (strData[i] != '+') && (strData[i] != '-'))
                        break;
                }
                if (i == strData.Length)
                {//OK, 整个都是 
                    strLeftDigital = strData;
                }
                else
                {
                    strLeftDigital = strData.Substring(0, i);
                    strRemanent = strData.Substring(i, strData.Length - i);
                }
            }
            catch { }
            //
            return strLeftDigital;
        }
        public static string fnGetIntStringAtRight(string strData, ref string strRemanent)
        {
            string strRightDigital = "0";
            strRemanent = "";
            try
            {
                strData = strData.Trim();
                int i = strData.Length;
                while (--i >= 0)
                {
                    if (!char.IsDigit(strData[i]) && (strData[i] != '+') && (strData[i] != '-'))
                        break;
                }
                if (i < 0)
                {//OK, 整个都是
                    strRightDigital = strData;
                }
                else
                {
                    strRemanent = strData.Substring(0, i);
                    strRightDigital = strData.Substring(i, strData.Length - i);
                }
            }
            catch { }
            //
            return strRightDigital;
        }
        //


        #region 为兼容以前的程序
        public static double GetDoubleAtStringLeft(string strData, ref string strRemanent)
        {
            return fnGetDoubleAtStringLeft(strData, ref strRemanent);
        }
        public static double GetDoubleAtStringRight(string strData, ref string strRemanent)
        {
            return fnGetDoubleAtStringRight(strData, ref strRemanent);
        }
        public static int GetIntAtStringLeft(string strData, ref string strRemanent)
        {
            return fnGetIntAtStringLeft(strData, ref strRemanent);
        }
        public static int GetIntAtStringRight(string strData, ref string strRemanent)
        {
            return fnGetIntAtStringRight(strData, ref strRemanent);
        }
        #endregion 
        //
        public static double fnGetDoubleAtStringLeft(string strData, ref string strRemanent)
        {// by: wYTw@163.com or wwYTww@Hotmail.com      Date: 2008-11-29 09:21:20
            double fRet = 0.0;
            string strLeftDigital = "0";
            strRemanent = "";
            try
            {
                strData = strData.Trim();
                int i;
                for (i = 0; i < strData.Length; i++)
                {
                    if (!char.IsDigit(strData[i]) && (strData[i] != '+') && (strData[i] != '-') && (strData[i] != '.'))
                        break;
                }
                if (i == strData.Length)
                {//OK, 整个都是 
                    strLeftDigital = strData;
                }
                else
                {
                    strLeftDigital = strData.Substring(0, i);
                    strRemanent = strData.Substring(i, strData.Length - i);
                }
                fRet = double.Parse(strLeftDigital);
            }
            catch { }
            //
            return fRet;
        }
        public static double fnGetDoubleAtStringRight(string strData, ref string strRemanent)
        {// by: wYTw@163.com or wwYTww@Hotmail.com      Date: 2008-11-29 09:21:25
            double fRet = 0.0;
            string strRightDigital = "0";
            strRemanent = "";
            try
            {
                strData = strData.Trim();
                int i = strData.Length;
                while (--i >= 0)
                {
                    if (!char.IsDigit(strData[i]) && (strData[i] != '+') && (strData[i] != '-') && (strData[i] != '.'))
                        break;
                }
                if (i < 0)
                {//OK, 整个都是
                    strRightDigital = strData;
                }
                else
                {
                    strRemanent = strData.Substring(0, i);
                    strRightDigital = strData.Substring(i, strData.Length - i);
                }
                fRet = double.Parse(strRightDigital);
            }
            catch { }
            //
            return fRet;
        }
        public static float fnGetFloatAtStringLeft(string strData, ref string strRemanent)
        {// by: wYTw@163.com or wwYTww@Hotmail.com      Date: 2009-11-21 12:29:09
            return (float)fnGetDoubleAtStringLeft(strData, ref strRemanent);
        }
        public static float fnGetFloatAtStringRight(string strData, ref string strRemanent)
        {// by: wYTw@163.com or wwYTww@Hotmail.com      Date: 2009-11-21 12:29:10
            return (float)fnGetDoubleAtStringRight(strData, ref strRemanent);
        }
        public static int fnGetIntAtStringLeft(string strData, ref string strRemanent)
        {// by: wYTw@163.com or wwYTww@Hotmail.com      Date: 2008-11-29 09:21:31
            int iRet = 0;
            string strLeftDigital = "0";
            strRemanent = "";
            try
            {
                strData = strData.Trim();
                int i;
                for (i = 0; i < strData.Length; i++)
                {
                    if (!char.IsDigit(strData[i]) && (strData[i] != '+') && (strData[i] != '-'))
                        break;
                }
                if (i == strData.Length)
                {//OK, 整个都是 
                    strLeftDigital = strData;
                }
                else
                {
                    strLeftDigital = strData.Substring(0, i);
                    strRemanent = strData.Substring(i, strData.Length - i);
                }
                iRet = int.Parse(strLeftDigital);
            }
            catch { }
            //
            return iRet;
        }
        public static int fnGetIntAtStringRight(string strData, ref string strRemanent)
        {// by: wYTw@163.com or wwYTww@Hotmail.com      Date: 2008-11-29 09:21:36
            int iRet = 0;
            string strRightDigital = "0";
            strRemanent = "";
            try
            {
                strData = strData.Trim();
                int i = strData.Length;
                while (--i >= 0)
                {
                    if (!char.IsDigit(strData[i]) && (strData[i] != '+') && (strData[i] != '-'))
                        break;
                }
                if (i < 0)
                {//OK, 整个都是
                    strRightDigital = strData;
                }
                else
                {
                    i++;
                    strRemanent = strData.Substring(0, i);
                    strRightDigital = strData.Substring(i, strData.Length - i);
                }
                iRet = int.Parse(strRightDigital);
            }
            catch { }
            //
            return iRet;
        }

        /// <summary>
        /// 按标准的IEEE浮点数格式换为十进制浮点数表示形式
        /// </summary>
        /// <param name="bIEEEs">没有倒序的4字节IEEE浮点数格式</param>
        /// <returns>十进制浮点数表示形式</returns>
        public static double fnIEEE2Float(byte[] bIEEEs)
        {
            double fRet = -1;
            bool isNegative = false;
            try
            {
                Array.Reverse(bIEEEs);//倒序
                uint iData = bIEEEs[0];
                iData <<= 8;
                iData += bIEEEs[1];
                iData <<= 8;
                iData += bIEEEs[2];
                iData <<= 8;
                iData += bIEEEs[3];
                //4字节共31-30....0bit,其中:
                //1、其第31bit 即符号位
                isNegative = (iData & 0x80000000) > 0;
                //3、第22～0bit 是二进制的纯小数0.010 0001 0000 0000 0000 0000，其十进制形式为0.2578125，即x = 0.2578125。 
                uint iBin = (iData & 0x007FFFFF);
                fRet = 0;
                for (int i = 1; i < 23; i++)
                {
                    if ((iBin & (1 << (23 - i))) > 0)
                        fRet += Math.Pow(2, -i);
                }
                //2、第30～23bit 即e。 
                iData >>= 23;
                uint ie = (iData & 0x000000FF);
                //计时浮点数值 by: wYTw@163.com or wwYTww@Hotmail.com      Date: 2009-12-25 21:15:26
                fRet = (1.0 + fRet) * Math.Pow(2, (ie - 127));
            }
            catch { }
            //
            if (isNegative)
                fRet = -fRet;
            return fRet;
        }


        public static byte fnBytes2CS(byte[] bBytes, int iStartPos, int iLen)
        {
            byte bCS = 0;
            try
            {
                for (int i = iStartPos; i < iLen; i++)
                {
                    unchecked
                    {
                        bCS += bBytes[i];
                    }
                }
            }
            catch { }
            //
            return bCS;
        }

    }


}
