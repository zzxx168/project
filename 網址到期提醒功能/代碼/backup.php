<?php
session_start();
//登入判斷
if(!isset($_SESSION['username'])){
    echo "<script>alert('請先登入');window.location.href='login.php'</script>";
}
//導入config
include_once('config.php');

//查詢domain資料表
$query1 = "select * from domain order by id ;";

//執行語句
$result1 = $pdo->prepare($query1);
$result1->execute();
$rows1=$result1->fetchAll(PDO::FETCH_ASSOC);

// 宣告$domainArray，用來儲存domain資料表資料
$domainArray =[];

//查詢domain_web資料表
$query2 = "select * from domain_web order by domain_id ;";
//執行語句
$result2 = $pdo->prepare($query2);
$result2->execute();
$rows2 = $result2->fetchAll(PDO::FETCH_ASSOC);

// 宣告$domainWebArray，用來儲存domain_web資料表資料
$domainWebArray = [];


//將domain資料存入陣列$domainArray
foreach ($rows1 as  $value) {
    $id = $value["id"];
    $domain = $value['domain'];
    $web = $value['web'];
    $expiry_date = $value['expiry_date'];
    // $domainArray[$id] = ["domain" =>$value['domain'], "web" => $value['web'], "expiry_date" => $value['expiry_date']];
    // $array = [1=>["Ddomain" => "godaddy", "web" => "cf.8iim.com", "date" => "2021-08-21"]];
    $domainArray[$id] = [$value['domain'], $value['web'], $value['expiry_date']];
}
//將domain_web資料存入陣列$domainWebArray
foreach ($rows2 as  $value) {
    $id = $value["domain_id"];
    $domain = $value['domain'];
    $web = $value['domain_web'];
    $domainWebArray[$id] = [$value['domain'], $value['domain_web']];
}

//將陣列轉為json格式
$jsonstr = json_encode($domainArray);
$jsonstr2 = json_encode($domainWebArray);

//將json存入domain_backup資料表
$query3 = "insert into domain_backup (json,json2) values (?,?)";
$result3 = $pdo->prepare($query3);
$result3->execute([$jsonstr, $jsonstr2]);

//回主頁
echo "<script>alert('當前資料已備份');window.location.href='index.php'; </script>";
