using Thinksoft.Patterns.Behavioral.State.Model;

namespace Thinksoft.Patterns.Behavioral.State.State
{
    /*
     *  The 'State' Interface.
     *  定義在某特定物流狀態下所需處理的操作
     */
    public interface ILogisticState
    {
        /**
         * 處理物流配送在當前狀態下的處理邏輯
         * @param context 物流主體，包含包裹資訊、客戶資訊及狀態轉換處理
         */
        void Handle(LogisticContext context);

        // 獲取狀態名稱
        string GetStateName();

        // 獲取狀態列舉值
        LogisticStateEnum GetStateEnum();
    }
}
