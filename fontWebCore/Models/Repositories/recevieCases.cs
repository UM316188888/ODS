﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fontWebCore.Models.Repositories
{
    public class recevieCases
    {
        public System.Guid recevie_id { get; set; }
        public string apply_method { get; set; }
        public Nullable<System.DateTime> recevie_date { get; set; }
        public string recevie_status { get; set; }
        public string customer_name { get; set; }
        public string customer_idcard_no { get; set; }
        public string customer_mobile_phone { get; set; }
        public System.DateTime customer_birthday { get; set; }
        public string customer_resident_tel_code { get; set; }
        public string customer_resident_tel_num { get; set; }
        public string customer_mail_tel_code { get; set; }
        public string customer_mail_tel_num { get; set; }
        public string customer_resident_postalcode { get; set; }
        public string customer_resident_addcity { get; set; }
        public string customer_resident_addregion { get; set; }
        public string customer_resident_address { get; set; }
        public string customer_mail_postalcode { get; set; }
        public string customer_mail_addcity { get; set; }
        public string customer_mail_addregion { get; set; }
        public string customer_mail_address { get; set; }
        public string customer_company_name { get; set; }
        public string customer_job_type { get; set; }
        public string customer_work_year { get; set; }
        public string customer_work_month { get; set; }
        public Nullable<int> customer_month_salary { get; set; }
        public string customer_company_tel_code { get; set; }
        public string customer_company_tel_num { get; set; }
        public string customer_company_tel_ext { get; set; }
        public string customer_creditcard_status { get; set; }
        public string customer_creditcard_status_remark { get; set; }
        public string customer_creditcard_bank { get; set; }
        public string customer_creditcard_validdate_month { get; set; }
        public string customer_creditcard_validdate_year { get; set; }
        public string card_num_01 { get; set; }
        public string card_num_02 { get; set; }
        public string card_num_03 { get; set; }
        public string card_num_04 { get; set; }
        public string contact_person_name_i { get; set; }
        public string contact_person_relation_i { get; set; }
        public string contact_person_mobile_phone_i { get; set; }
        public string contact_person_areacode_i { get; set; }
        public string contact_person_tel_i { get; set; }
        public string contact_person_company_areacode_i { get; set; }
        public string contact_person_company_tel_i { get; set; }
        public string contact_person_company_tel_ext_i { get; set; }
        public string guarantor_relation { get; set; }
        public string guarantor_name { get; set; }
        public string guarantor_idcard_no { get; set; }
        public Nullable<System.DateTime> guarantor_birthday { get; set; }
        public string guarantor_mobile_phone { get; set; }
        public string guarantor_resident_tel_code { get; set; }
        public string guarantor_resident_tel_num { get; set; }
        public string guarantor_company_tel_code { get; set; }
        public string guarantor_company_tel_num { get; set; }
        public string guarantor_company_tel_ext { get; set; }
        public string note_time { get; set; }
        public string dealer_branch_name { get; set; }
        public string product_name { get; set; }
        public Nullable<int> staging_amount { get; set; }
        public string num { get; set; }
        public string num_amount { get; set; }
        public string note_remark { get; set; }
        public Nullable<bool> is_secret { get; set; }
    }
}