<?php
//連接MySQL服務器，選擇數據庫連接MySQL服務器，選擇數據庫
include_once('config.php');
//獲取POST方式提交的數據
$domain = $_POST["domain"];
$web = $_POST["web"];
$date = $_POST["date"];

//mysql插入語句
$sql="insert into domain(domain,web,expiry_date) values(?,?,?) ";

$result = $pdo->prepare($sql);
$result->execute([$domain, $web, $date]);

echo "<script>window.location.href='index.php';</script>";