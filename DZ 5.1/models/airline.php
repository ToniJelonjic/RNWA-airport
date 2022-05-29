<?php
    class Airline  {
        private $AirlineId;
        private $Iata;
        private $Airlinename;
        private $Base_Airport;

        public function __construct($AirlineId = null, $Iata, $Airlinename, $Base_Airport) {
            $this->Iata = $Iata;
            $this->Airlinename = $Airlinename;
            $this->Base_Airport = $Base_Airport;
        }


        public function getAirlineId() {
            return $this->AirlineId;
        }

        public function getIata() {
            return $this->Iata;
        }
        public function setIata($name) {
            return $this->Iata = $name;
        }
        
        public function getAirlinename() {
            return $this->Airlinename;
        }
        public function setAirlinename($Airlinename) {
            return $this->Airlinename = $Airlinename;
        }

        public function getBase_Airport() {
            return $this->Base_Airport;
        }
        public function setBase_Airport($Base_Airport) {
            return $this->Base_Airport = $Base_Airport;
        }

        public static function getAllAirlines() {
            $Airlines = [];
            $db = Db::getInstance();
            $request = $db->query('SELECT * FROM airline');
                foreach($request->fetchAll() as $cult) {
                $list[] = new Airline($cult['AirlineId'], $cult['Iata'], $cult['Airlinename'], $cult['Base_Airport']);
            }

            return $Airlines;
          }


          public static function findById($id) {
            $db = Db::getInstance();

            $request = $db->prepare('SELECT * FROM airline WHERE AirlineId = :id');
            $request->execute(array('id' => $id));
            $Airline = $request->fetch();
            
            if ($Airline) {
                return new Airline($Airline['AirlineId'], $Airline['Iata'], $Airline['Airlinename'], $Airline['Base_Airport']);
            } else {
                return [];
            }
          }


          public function editAirlineById($id, $newIata, $newAirlinename, $newBase_Airport){
            $db = Db::getInstance();

            $sql = "UPDATE Airline SET 'Iata' = '$newIata', 'Airlinename' = '$newAirlinename', 'Base_airport' = '$newBase_Airport') VALUES WHERE AirlineId = '$id'";

            if ($db->query($sql) == TRUE){
                $rez="Airline updated!";
            } else {
                $rez="Airline not updated!";;
            }
            
            return $rez; 
          }


          public function addAirline($AirlineId, $Iata, $Airlinename){
            $db = Db::getInstance();

            $sql = "INSERT INTO airline (`AirlineId`, `Iata`, `Airlinename`, ') VALUES ('$AirlineId', '$Iata', '$Airlinename')";

            if ($db->query($sql) == TRUE){
                $rez="Airline added!";
            } else {
                $rez="Airline not added!";;
            }
            
            return $rez; 
          }


          public static function deleteAirlineById($id) {
            $db = Db::getInstance();
            $sql = "DELETE FROM airline WHERE AirlineId = '$id'";

            if ($db->query($sql) == TRUE){
                $rez="Culture deleted";
            } else {
                $rez="Deletion error!";;
            }
            
            return $rez; 
        }
    }
?>