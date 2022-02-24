using System;

namespace SharedModels
{
    public interface IBaseProject
    {
        DateTime? CreatedDate { get; set; }
        string Data { get; set; }
        string Description { get; set; }
        Image[] Images { get; set; }
        int ProjectTypeID { get; set; }
        string[] Tags { get; set; }
        string Title { get; set; }

        void EncodeData();
        void DecodeData();
    }
}