﻿<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PhotoUploadHelp.ascx.cs"
    Inherits="UserControl_PhotoUploadHelp" %>
<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dxp" %>
<%@ Register Assembly="TSP.WebControls" Namespace="TSP.WebControls" TagPrefix="TSPControls" %>


<TSPControls:CustomASPxRoundPanel ID="RoundPanelMeInfo" runat="server" Width="100%"
    HeaderText="راهنمای بارگذاری تصاویر" ShowCollapseButton="true" AllowCollapsingByHeaderClick="true" Collapsed="true">


    <PanelCollection>

        <dx:PanelContent ID="PanelContent1" runat="server" SupportsDisabledAttribute="True">
      
                
                    <p class="HelpUL">
                        در هنگام بارگذاری تصاویر به موارد زیر دقت کنید در غیر اینصورت کل درخواست شما کاملا
                                    باطل می گردد. در صورتی که رعایت مطالب زیر برای شما گیج کننده و دشوار است از فرد
                                    متخصصی در زمینه ویرایش تصاویر کمک بگیرید
                    </p>
                    <dt>تصویر پرسنلی</dt>
                    <dd>عکس پرسنلی باید رنگی با الف) زمینه کاملا سفید ب)بدون کادر ج)جدید باشد. همانند تصویر
                                    گذرنامه
                    </dd>
                    <dd>زاویه عکس از رو برو باشد و قرص صورت کاملا مشخص باشد</dd>
                    <dd>عکس باید مطابق موازین رسمی جمهوری اسلامی ایران باشد. برای آقایان عکس با زمينه سفيد،
                                    کت و پیراهن یقه دار باشد.عکس با تی شرت, تکپوش, عينک، کراوات و دیگر تزئینات مورد
                                    قبول نمی باشد برای خانم ها عکس با زمينه سفيد، قرص صورت کاملا مشخص و با حجاب کامل
                                    و پوشش مغنعه باشد. عکس با روسری و شال مورد قبول نمی باشد.</dd>
                    <dd>حجم تصویر باید بین 250 تا 300 کیلو بایت باشد</dd>
                    <dd>حداقل عمق وضوح تصویر باید 300dpi باشد</dd>
                    <dd>نسبت اندازه تصویر 920 پیکسل در 720 پیکسل می باشد</dd>
                    <dd>تصویر در جهت درست اسکن و بارگذاری شوند و هیچ گونه چرخشی نداشته باشد و توجه داشته
                                    باشید که در هنگام اسکن تصویر رنگ تصویر تغییر نکند برای مثال زمینه سفید عکس تیره
                                    نشود.</dd>
                    <dd>پیشنهاد می شود از آتلیه عکاسی فایل دیجیتال تصویر گذرنامه ای را با مشخصات ذکر شده
                                    دریافت کنید که مشکلات اسکن و ویرایش تصویر برایتان حذف شود</dd>
                    <dt>دیگر تصاویر</dt>
                    <dd>حداقل حجم تصاویر 100 کیلو بایت و حداکثر حجم تصاویر 300 کیلو بایت</dd>
                    <dd>عمق وضوحی حدود 150dpi برای این تصاویر کافی است
                    </dd>
                    <dd>تصاویر باید رنگی باشند</dd>
                    <dd>تصاویر باید کاملا واضح بدون تغییر در نسبت طول و عرض بدون اعوجاج و در اندازه واقعی
                                    یا بزرگتر از آن و قابل چاپ و رویت مجدد باشند</dd>
                    <dd>تصاویر در جهت درست اسکن و بارگذاری شوند و هیچ گونه چرخشی نداشته باشد و توجه داشته
                                    باشید که در هنگام اسکن تصاویر رنگ تصویر تغییر نکند برای مثال زمینه سفید عکس تیره
                                    نشود.
                    </dd>
                    <dd>منظور از تصویر کارت ملی تصاویر روی و پشت آن – منظور از تصویر کارت پایان خدمت تصاویر
                                    روی و پشت آن – و منظور از تصویر شناسنامه تصاویر صفحه اول و صفحه توضیحات می باشد
                                    برای مثال با کمک برنامه های ویرایش تصویر باید تصویر روی و پشت کارت ملی را در جهت
                                    درست زیر هم قرار داد و سپس تصویر حاصل شده که شامل روی پشت کارت ملی است را بارگذاری
                                    کرد
                    </dd>
                    <p>ما پیشنهاد می کنیم برای ویرایش تصاویر و کنترل حجم رنگ و اندازه آنها از برنامه فتوشاپ یا از برنامه بسیارساده ویرایشگر تصاویر از مجموعه مایکروسافت آفیس استفاده بفرمایید </p>
           
      
        </dx:PanelContent>
    </PanelCollection>
</TSPControls:CustomASPxRoundPanel>

