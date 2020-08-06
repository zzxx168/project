<?php
//連接MySQL服務器，選擇數據庫連接MySQL服務器，選擇數據庫
include_once('config.php');
//獲取id
$id=$_GET['id'];

//mysql查詢語句

$sql="select * from domain where id =".$id;

////執行mysql語句
// $result=mysqli_query($link,$sql);

$result = $pdo->prepare($sql);
$result->execute();

//獲取關聯數組形式的結果集
// $rows=mysqli_fetch_array($result,MYSQLI_ASSOC);

$rows=$result->fetch(PDO::FETCH_ASSOC);
//導入edit.html
include_once('editDate.html');


