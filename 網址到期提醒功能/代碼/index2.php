<?php

//使用seesion做登入判斷
session_start();

if(!isset($_SESSION['username'])){
    echo "<script>alert('請先登入');window.location.href='login.php'</script>";
}
//導入$pdo
include_once('config.php');

//查詢domain_web
$query1 = "select * from domain_web order by domain_id ;";
$result1 = $pdo->prepare($query1);
$result1->execute();
$rows1=$result1->fetchAll(PDO::FETCH_ASSOC);

//將domain_web的domain, domain_web以鍵值存入陣列
$domainArray =[];
foreach ($rows1 as  $value) {
    $domainArray[$value['domain']] = $value["domain_web"];
}

//導入domain.php
 include_once('domain.php');