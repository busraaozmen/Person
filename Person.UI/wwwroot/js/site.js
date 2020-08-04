$("#personelGetir").click(function () {
    $.ajax({
        type: 'GET',
        url: 'http://localhost:51782/api/Kisiler',
        success: function (kisi) {
            $("#kisiGetir").html("");
            $.each(kisi, function (index, value) {
                $("#kisiGetir")
                    .append("<li>Personel Id: <b>" + value.id + " - Personel Adı: <b>" + value.ad + " - Personel Soyadı: <b>" + value.soyad + "</b>" + " - Personel Giriş Tarihi: <b>" + value.personelBilgi.girisTarihi + "</b>" + " - Personel Çıkış Tarihi: <b>" + value.personelBilgi.cikisTarihi + "</b>");
            });
        }
    });
});