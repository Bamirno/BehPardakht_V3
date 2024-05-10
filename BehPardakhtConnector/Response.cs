using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using static POS_PC_v3.Result;

namespace BehPardakhtConnector
{


    public class Response
    {
        public bool Status { get; set; }
        public string Message { get; set; }
        public ResponseData Data { get; set; }

        public Response(POS_PC_v3.Result result)
        {
            var code = (return_codes)result.ReturnCode;
            Message = GetPersianMessage(code);
            if (code != return_codes.RET_OK)
            {
                Status = false;
                Data = null;
            }
            else
            {
                Status = true;
                Data = new ResponseData
                {
                    Amount = result?.TotalAmount,
                    AccountNumber = result?.AccountNo,
                    TransactionDate = result?.TransactionDate,
                    CardNumber = result?.PAN,
                    TransactionSerialNumber = result?.SerialTransaction,
                    TransactionTerminalNumber = result?.TerminalNo,
                    TransactionRegisterNumber = result?.TraceNumber,
                    TransactionTime = result?.TransactionTime
                };
            }
        }

        private string GetPersianMessage(return_codes resultCode)
        {
            switch (resultCode)
            {
                case return_codes.RET_OK:
                    return "عملیات با موفقیت انجام شد";
                case return_codes.ERR_PC_INVALID_REC_SIZE:
                    return "اندازه رکورد نامعتبر است";
                case return_codes.ERR_POS_INVALID_DATA:
                    return "داده نامعتبر است";
                case return_codes.ERR_PC_INVALID_REC_PROCESS_CODE:
                    return "کد پردازش رکورد نامعتبر است";
                case return_codes.ERR_PC_INVALID_AMOUNT:
                    return "مقدار نامعتبر است";
                case return_codes.ERR_PC_INVALID_INPUT_PAYERID:
                    return "شناسه پرداخت‌کننده نامعتبر است";
                case return_codes.ERR_PC_INVALID_INPUT_TIMEOUT:
                    return "زمان انتظار نامعتبر است";
                case return_codes.ERR_PC_PORT_TIMEOUT_FOR_REC:
                    return "زمان انتظار برای دریافت رکورد";
                case return_codes.ERR_POS_RESPONSE_RECEIVED_TOO_LATE:
                    return "پاسخ به زمان نرسیده است";
                case return_codes.ERR_POS_FAILED_TRANSACTION:
                    return "تراکنش ناموفق است";
                case return_codes.ERR_POS_PRINTER:
                    return "مشکل در چاپ";
                case return_codes.ERR_POS_COMMUNICATION:
                    return "مشکل در ارتباط";
                case return_codes.ERR_POS_TO_SEND_TRANSACTION:
                    return "مشکل در ارسال تراکنش";
                case return_codes.ERR_PC_INVALID_INPUT_PORTNAME:
                    return "نام پورت ورودی نامعتبر است";
                case return_codes.ERR_POS_USER_ABORT:
                    return "کاربر تراکنش را لغو کرده است";
                case return_codes.ERR_PC_INVALID_INPUT_BILLID:
                    return "شناسه قبض نامعتبر است";
                case return_codes.ERR_PC_INVALID_INPUT_PAYID:
                    return "شناسه پرداخت‌کننده نامعتبر است";
                case return_codes.ERR_PC_PORT_OPEN_FAILED:
                    return "باز کردن پورت ناموفق بود";
                case return_codes.ERR_PC_PORT_ACCESS_FAILED:
                    return "دسترسی به پورت ناموفق بود";
                case return_codes.ERR_PC_INVALID_PORT_STATE:
                    return "وضعیت پورت نامعتبر است";
                case return_codes.ERR_PC_INVALID_PORT_PARAMETERS:
                    return "پارامترهای پورت نامعتبر است";
                case return_codes.ERR_PC_INVALID_PORT_NAME:
                    return "نام پورت نامعتبر است";
                case return_codes.ERR_PC_NULL_STR_TO_WRITE_IN_PORT:
                    return "رشته خالی برای نوشتن در پورت";
                case return_codes.ERR_PC_PORT_TIMEOUT_FOR_SEND:
                    return "زمان انتظار برای ارسال پورت";
                case return_codes.ERR_POS_CARD_SWIPE_FAILED:
                    return "خواندن کارت ناموفق است";
                case return_codes.ERR_PC_INVALID_INPUT_ACCOUNTID:
                    return "شناسه حساب نامعتبر است";
                case return_codes.ERR_POS_INVALID_INPUT_ACCOUNTID:
                    return "شناسه حساب نامعتبر است";
                case return_codes.ERR_POS_INVALID_INPUT_PAYERID:
                    return "شناسه پرداخت‌کننده نامعتبر است";
                case return_codes.ERR_POS_INVALID_INPUT_AMOUNT:
                    return "مقدار نامعتبر است";
                case return_codes.ERR_POS_INVALID_INPUT_REFRENCE_NUMBER:
                    return "شماره مرجع نامعتبر است";
                case return_codes.ERR_POS_INVALID_INPUT_BILL_ID:
                    return "شناسه قبض نامعتبر است";
                case return_codes.ERR_POS_INVALID_INPUT_PAYMENT_ID:
                    return "شناسه پرداخت نامعتبر است";
                case return_codes.ERR_POS_INVALID_INPUT_ADDITIONALDATA:
                    return "داده‌های اضافی نامعتبر است";
                case return_codes.ERR_POS_INVALID_MULTI_PAYMENT_AMOUNT:
                    return "مقدار چندپرداختی نامعتبر است";
                case return_codes.ERR_POS_UNCONFIRM_REC_DATA:
                    return "داده‌های دریافتی تایید نشده است";
                case return_codes.ERR_PC_INVALID_INPUT_MULTI_PAYMENT_REQUEST_LIST:
                    return "لیست درخواست‌های چندپرداختی نامعتبر است";
                case return_codes.ERR_PC_INVALID_INPUT_MULTI_PAYMENT_AMOUNT:
                    return "مقدار چندپرداختی نامعتبر است";
                case return_codes.ERR_PC_INVALID_INPUT_REFERENCE_NUMBER:
                    return "شماره مرجع نامعتبر است";
                case return_codes.ERR_POS_PC_CRCERROR_INVALID_DATA:
                    return "خطای CRC در داده‌های نامعتبر";
                case return_codes.ERR_PC_INVALID_POSPC_COMMUNICATION_TYPE:
                    return "نوع ارتباط POSPC نامعتبر است";
                case return_codes.ERR_PC_INVALID_INPUT_TCP_SOCKET_PORT:
                    return "پورت TCP Socket نامعتبر است";
                case return_codes.ERR_PC_INVALID_INPUT_TCP_SOCKET_RECEIVED_TIMEOUT:
                    return "زمان انتظار دریافت پورت TCP Socket نامعتبر است";
                case return_codes.ERR_PC_TCP_SOCKET_FAILED:
                    return "عدم موفقیت در اتصال به پورت TCP Socket";
                case return_codes.ERR_PC_TCP_SOCKET_SEND_MSG_FAILED:
                    return "ارسال پیام به پورت TCP Socket ناموفق بود";
                case return_codes.ERR_PC_TCP_SOCKET_RECEIVED_MSG_FAILED:
                    return "دریافت پیام از پورت TCP Socket ناموفق بود";
                case return_codes.ERR_PC_INVALID_INPUT_MERCHANT_MESSAGE:
                    return "پیام بازرگان نامعتبر است";
                case return_codes.ERR_PC_PREPARE_TLV_MSG_FAILED:
                    return "آماده‌سازی پیام TLV ناموفق بود";
                case return_codes.ERR_PC_PORT_EXCEPTION_FOR_REC:
                    return "استثنای پورت برای دریافت";
                case return_codes.ERR_PC_NULL_STR_IN_READ_PORT:
                    return "رشته خالی در پورت خوانده شده";
                case return_codes.ERR_PC_CALCULATE_CRC_ERROR:
                    return "خطای محاسبه CRC";
                case return_codes.ERR_PC_INVALID_INPUT_MERCHANT_FIELD:
                    return "فیلد بازرگان نامعتبر است";
                case return_codes.RET_OK_RequestID:
                    return "عملیات با موفقیت انجام شد - شناسه درخواست";
                case return_codes.RET_POS_Busy:
                    return "دستگاه پوز مشغول است";
                case return_codes.ERR_POS_PC_OTHER:
                    return "خطای دیگر در دستگاه پوز";
                default:
                    return "کد نامعتبر";
            }
        }

    }

    public class ResponseData
    {
        public string Amount { get; set; }
        public string AccountNumber { get; set; }
        public string TransactionDate { get; set; }
        public string TransactionTime { get; set; }
        public string CardNumber { get; set; }
        public string TransactionSerialNumber { get; set; }
        public string TransactionTerminalNumber { get; set; }
        public string TransactionRegisterNumber { get; set; }


    }
}
