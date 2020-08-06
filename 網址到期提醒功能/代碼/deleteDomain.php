<?php
//導入config
include_once('config.php');
//獲取網域
$domain=$_POST['domain'];

//mysql刪除語句
$sql1="delete from domain where domain = ?";
$sql2="delete from domain_web where domain = ?";

//執行mysql語句
$result1 = $pdo->prepare($sql1);
$result1->execute([$domain]);

$result2 = $pdo->prepare($sql2);
$result2->execute([$domain]);


echo "<script> window.location.href='index.php';</script>";