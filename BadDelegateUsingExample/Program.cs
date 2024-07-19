using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadDelegateUsingExample
{
    class Program//下面这段代码 如果出现问题，光定位问题都需要花上十几个小时，然后去更改    委托滥用的例子
    {
        static void Main(string[] args)
        {
            Operation opt1 = new Operation();
            Operation opt2 = new Operation();
            Operation opt3 = new Operation();

            opt3.InnerOperation = opt2;  //形成操作链
            opt2.InnerOperation = opt1;

            opt3.Operate(new object(), null, null);
            //问题1：如果传入的两个参数为null，失败和成功的效果是什么？ 答：内层的操作会调用外层的回调！
            //问题2：如果传入的两个参数不为null，会出现什么情况？ 答：所有默认callback都被“穿透性”屏蔽
        }
    }
    class Operation
    {
        public Action DefaultSuccessCallback { get; set; }
        public Action DefaultFailuerCallback { get; set; }
        public Operation InnerOperation { get; set; }

        public object Operate(object input,Action successCallback,Action failureCallback)
        {
            if (successCallback==null)
            {
                successCallback = this.DefaultSuccessCallback;
            }
            if (failureCallback==null)
            {
                failureCallback = this.DefaultFailuerCallback;
            }
            object result = null;
            try
            {
                result = this.InnerOperation.Operate(input, successCallback, failureCallback);
            }
            catch 
            {

                failureCallback.Invoke();
            }
            successCallback.Invoke();
            return result;
        }
    }
}
