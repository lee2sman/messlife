<?php 

$data = 'data:image/png;base64,'.$_POST['base64data'];

list($type, $data) = explode(';', $data);
list(, $data)      = explode(',', $data);
$data = base64_decode($data);


$timestamp = date("Y-m-d_H-i-s");
$fileName = ''.$timestamp.'-image.png';
file_put_contents($fileName, $data);
?>