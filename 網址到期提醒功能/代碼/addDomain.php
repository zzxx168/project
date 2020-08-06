<?php
//導入config
include_once('config.php');

//獲取POST數據
$domain = $_POST["domain"];
$web = $_POST["domain_web"];

//mysql插入語句
$sql="insert into domain_web(domain, domain_web) values(?,?);";

$result = $pdo->prepare($sql);
$result->execute([$domain, $web]);
//返回主頁
echo "<script>window.location.href='index.php';</script>";