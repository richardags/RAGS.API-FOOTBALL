﻿using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using RAGS.API_FOOTBALL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace RAGS.API_FOOTBALL
{
    public static class Enumerations
    {
        public static string NameToString(this CountriesNames name)
        {
            switch (name)
            {
                case CountriesNames.Burkina_Faso:
                case CountriesNames.Chinese_Taipei:
                case CountriesNames.Congo_DR:
                case CountriesNames.Costa_Rica:
                case CountriesNames.Czech_Republic:
                case CountriesNames.Dominican_Republic:
                case CountriesNames.El_Salvador:
                case CountriesNames.Faroe_Islands:
                case CountriesNames.Hong_Kong:
                case CountriesNames.Ivory_Coast:
                case CountriesNames.New_Zealand:
                case CountriesNames.Northern_Ireland:
                case CountriesNames.San_Marino:
                case CountriesNames.Saudi_Arabia:
                case CountriesNames.South_Africa:
                case CountriesNames.South_Korea:
                case CountriesNames.Trinidad_And_Tobago:
                case CountriesNames.United_Arab_Emirates:
                    return name.ToString().Replace("_", "-");
                default:
                    return name.ToString();
            }
        }
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum CountriesCode
    {
        AL,
        DZ,
        AD,
        AO,
        AR,
        AM,
        AW,
        AU,
        AT,
        AZ,
        BH,
        BD,
        BB,
        BY,
        BE,
        BZ,
        BJ,
        BM,
        BT,
        BO,
        BA,
        BW,
        BR,
        BG,
        BF,
        BI,
        KH,
        CM,
        CA,
        CL,
        CN,
        TW,
        CO,
        CD,
        CG,
        CR,
        UA,
        HR,
        CU,
        CW,
        CY,
        CZ,
        DK,
        DO,
        EC,
        EG,
        SV,
        GB,
        EE,
        SZ,
        ET,
        FO,
        FJ,
        FI,
        FR,
        GA,
        GM,
        GE,
        DE,
        GH,
        GI,
        GR,
        GP,
        GT,
        GN,
        HT,
        HN,
        HK,
        HU,
        IS,
        IN,
        ID,
        IR,
        IQ,
        IE,
        IL,
        IT,
        CI,
        JM,
        JP,
        JO,
        KZ,
        KE,
        XK,
        KW,
        KG,
        LA,
        LV,
        LB,
        LS,
        LR,
        LY,
        LI,
        LT,
        LU,
        MO,
        MK,
        MW,
        MY,
        MV,
        ML,
        MT,
        MR,
        MU,
        MX,
        MD,
        MN,
        ME,
        MA,
        MM,
        NA,
        NP,
        NL,
        NZ,
        NI,
        NG,
        NO,
        OM,
        PK,
        PS,
        PA,
        PY,
        PE,
        PH,
        PL,
        PT,
        QA,
        RO,
        RU,
        RW,
        SM,
        SA,
        SN,
        RS,
        SG,
        SK,
        SI,
        SO,
        ZA,
        KR,
        ES,
        SD,
        SR,
        SE,
        CH,
        SY,
        TJ,
        TZ,
        TH,
        TT,
        TN,
        TR,
        TM,
        UG,
        AE,
        UY,
        US,
        UZ,
        VE,
        VN,
        ZM,
        ZW
    }
    [JsonConverter(typeof(StringEnumConverter))]
    public enum CountriesNames
    {
        Albania,
        Algeria,
        Andorra,
        Angola,
        Argentina,
        Armenia,
        Aruba,
        Australia,
        Austria,
        Azerbaidjan,
        Bahrain,
        Bangladesh,
        Barbados,
        Belarus,
        Belgium,
        Belize,
        Benin,
        Bermuda,
        Bhutan,
        Bolivia,
        Bosnia,
        Botswana,
        Brazil,
        Bulgaria,
        [EnumMember(Value = "Burkina-Faso")]
        Burkina_Faso,
        Burundi,
        Cambodia,
        Cameroon,
        Canada,
        Chile,
        China,
        [EnumMember(Value = "Chinese-Taipei")]
        Chinese_Taipei,
        Colombia,
        Congo,
        [EnumMember(Value = "Congo-DR")]
        Congo_DR,
        [EnumMember(Value = "Costa-Rica")]
        Costa_Rica,
        Crimea,
        Croatia,
        Cuba,
        Curacao,
        Cyprus,
        [EnumMember(Value = "Czech-Republic")]
        Czech_Republic,
        Denmark,
        [EnumMember(Value = "Dominican-Republic")]
        Dominican_Republic,
        Ecuador,
        Egypt,
        [EnumMember(Value = "El-Salvador")]
        El_Salvador,
        England,
        Estonia,
        Eswatini,
        Ethiopia,
        [EnumMember(Value = "Faroe-Islands")]
        Faroe_Islands,
        Fiji,
        Finland,
        France,
        Gabon,
        Gambia,
        Georgia,
        Germany,
        Ghana,
        Gibraltar,
        Greece,
        Guadeloupe,
        Guatemala,
        Guinea,
        Haiti,
        Honduras,
        [EnumMember(Value = "Hong-Kong")]
        Hong_Kong,
        Hungary,
        Iceland,
        India,
        Indonesia,
        Iran,
        Iraq,
        Ireland,
        Israel,
        Italy,
        [EnumMember(Value = "Ivory-Coast")]
        Ivory_Coast,
        Jamaica,
        Japan,
        Jordan,
        Kazakhstan,
        Kenya,
        Kosovo,
        Kuwait,
        Kyrgyzstan,
        Laos,
        Latvia,
        Lebanon,
        Lesotho,
        Liberia,
        Libya,
        Liechtenstein,
        Lithuania,
        Luxembourg,
        Macao,
        Macedonia,
        Malawi,
        Malaysia,
        Maldives,
        Mali,
        Malta,
        Mauritania,
        Mauritius,
        Mexico,
        Moldova,
        Mongolia,
        Montenegro,
        Morocco,
        Myanmar,
        Namibia,
        Nepal,
        Netherlands,
        [EnumMember(Value = "New-Zealand")]
        New_Zealand,
        Nicaragua,
        Nigeria,
        [EnumMember(Value = "Northern-Ireland")]
        Northern_Ireland,
        Norway,
        Oman,
        Pakistan,
        Palestine,
        Panama,
        Paraguay,
        Peru,
        Philippines,
        Poland,
        Portugal,
        Qatar,
        Romania,
        Russia,
        Rwanda,
        [EnumMember(Value = "San-Marino")]
        San_Marino,
        [EnumMember(Value = "Saudi-Arabia")]
        Saudi_Arabia,
        Scotland,
        Senegal,
        Serbia,
        Singapore,
        Slovakia,
        Slovenia,
        Somalia,
        [EnumMember(Value = "South-Africa")]
        South_Africa,
        [EnumMember(Value = "South-Korea")]
        South_Korea,
        Spain,
        Sudan,
        Surinam,
        Sweden,
        Switzerland,
        Syria,
        Tajikistan,
        Tanzania,
        Thailand,
        [EnumMember(Value = "Trinidad-And-Tobago")]
        Trinidad_And_Tobago,
        Tunisia,
        Turkey,
        Turkmenistan,
        Uganda,
        Ukraine,
        [EnumMember(Value = "United-Arab-Emirates")]
        United_Arab_Emirates,
        Uruguay,
        USA,
        Uzbekistan,
        Venezuela,
        Vietnam,
        Wales,
        World,
        Zambia,
        Zimbabwe
    }
}