using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Myzj.OPC.UI.Model.AdminCarriage
{
    public class BuyAppointGoods
    {
        public List<BuyAppointGoodsParam> BuyAppointGoodsParams { get; set; }
        public int NotMeetIsExec { get; set; }
    }

    public class BuyAppointGoodsParam
    {
        public List<string> Platforms { get; set; }
        public List<string> GoodsIds { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public int FullCarriage { get; set; }
        public int Priority { get; set; }
    }


    public class FreeShipping 
    {
        public List<FreeShippingParam> FreeShippingParams { get; set; } 
        public int NotMeetIsExec { get; set; }
    }

    public class FreeShippingParam
    {
        public List<int> Platforms { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public int FullCarriage { get; set; }
        public int Priority { get; set; }
    }


    public class SeaWashesOrderMoney
    {
        public List<SeaWashesOrderMoneyParam> SeaWashesOrderMoneyParams { get; set; }
        public int NotMeetIsExec { get; set; }
    }

    public class SeaWashesOrderMoneyParam
    {
        public List<int> Suppliers { get; set; }
        public List<OrderMoneyItem> OrderMoneyList { get; set; }
        public string NotFullMessage { get; set; }
        public string FullMessage { get; set; }
        public int Priority { get; set; }
    }

    public class OrderMoneyItem
    {
        public int OrderStartMoney { get; set; }
        public int OrderEndMoney { get; set; }
        public int Carriage { get; set; }
        public int Priority { get; set; }
    }

    public class Level
    {
        public List<LevelParam> LevelParams { get; set; }
        public int NotMeetIsExec { get; set; }
    }

    public class LevelParam
    {
        public List<int> Levels { get; set; }
        public int FreeShippingMoney { get; set; }
        public int FullCarriage { get; set; }
        public int NoFullCarriage { get; set; }
        public int Priority { get; set; }
    }


    public class JZH
    {
        public List<JZHParam> JZHParams { get; set; }
        public int NotMeetIsExec { get; set; }
    }

    public class JZHParam
    {
        public List<int> AreaIds { get; set; }
        public List<int> ExcludeAreaIds { get; set; }
        public List<JZHSection> JZHSections { get; set; }
        public int Priority { get; set; }
    }

    public class JZHSection
    {
        public int StartMoney { get; set; }
        public int EndMoney { get; set; }
        public int Carriage { get; set; }
    }



    public class _OtherParams
    {
        public List<OtherParam> OtherParams { get; set; }
        public int NotMeetIsExec { get; set; }
    }

    public class OtherParam
    {
        public List<int> AreaIds { get; set; }
        public List<int> ExcludeAreaIds { get; set; }
        public List<JZHSection> OtherSections { get; set; }
        public int Priority { get; set; }
    }


    public class _RemoteParams
    {
        public List<RemoteParam> RemoteParams { get; set; }
        public int NotMeetIsExec { get; set; }
    }

    public class RemoteParam
    {
        public List<int> AreaIds { get; set; }
        public List<int> ExcludeAreaIds { get; set; }
        public List<RemoteSection> RemoteSections { get; set; }
        public int Priority { get; set; }
    }

    public class RemoteSection
    {
        public int StartMoney { get; set; }
        public int EndMoney { get; set; }
        public int FirstWeight { get; set; }
        public int FirstPrice { get; set; }
        public int AddWeight { get; set; }
        public int AddPrice { get; set; }
    }


    public class SeaWashesBuyCount
    {
        public List<SeaWashesBuyCountParam> SeaWashesBuyCountParams { get; set; }
        public int NotMeetIsExec { get; set; }
    }

    public class SeaWashesBuyCountParam
    {
        public List<int> Suppliers { get; set; }
        public int BuyCount { get; set; }
        public int FullCarriage { get; set; }
        public int NoFullCarriage { get; set; }
        public int Priority { get; set; }
    }


    public class SeaWashesWeight
    {
        public List<SeaWashesWeightParam> SeaWashesWeightParams { get; set; }
        public int NotMeetIsExec { get; set; }
    }

    public class SeaWashesWeightParam
    {
        public List<int> Suppliers { get; set; }
        public List<_WeightList> WeightList { get; set; }
        public int Priority { get; set; }
    }

    public class _WeightList
    {
        public int StartWeight { get; set; }
        public int EndWeight { get; set; }
        public int Carriage { get; set; }
        public int Priority { get; set; }
    }


    namespace power
    {
        public class BuyAppointGoods
        {
            public List<BuyAppointGoodsParam> BuyAppointGoodsParams { get; set; }
            public int NotMeetIsExec { get; set; }
        }

        public class BuyAppointGoodsParam
        {
            public List<int> Platforms { get; set; }
            public List<int> GoodsIds { get; set; }
            public string StartTime { get; set; }
            public string EndTime { get; set; }
            public int FullCarriage { get; set; }
            public int Priority { get; set; }
        }
    }
}
