## Racoon Runner

# Descriere

Raccoon Run este un joc 3D care ruleaza la nesfarsit, in care personajul principal este un raton. Jucatorul controleaza ratonul care alearga, scopul fiind de a evita obstacolele.

# Gameplay
Personajul poate fi controlat atat prin sageti, cat si prin tastele WASD. Pentru a sari se utilizeaza ori sageata in sus, ori tasta space. De asemenea, se poate folosi si un joystick.

Jucatorul trebuie sa ocoleasca obstacolele, care sunt de doua tipuri: bariere sau containere. Peste bariere se poate sari, insa peste containere nu, ele trebuind ocolite complet.

Scorul este proportional numarul de stelute culese.

In timpul jocului, se poate profita de power-up-urile dispuse de-a lungul hartii. Acestea sunt:

    • un reward care creste scorul cu 10 puncte

    • un perk care dubleaza scorul oferit de stele pentru urmatoarele 10 secunde

    • un perk care ofera invincibilitate pentru urmatoarele 5 secunde, iar fiecare obstacol de care se loveste ratonul  adauga 15 puncte la scor
	
# UI & UX
Meniul de start are doua butoane, unul pentru inceperea jocului si unul pentru a opri sau a porni sunetul.

Meniul de Game Over afiseaza scorul curent, cat si cel mai mare scor inregistrat, impreuna cu butonul de reincepere a jocului si cel de revenire la meniu.

# Dezvoltarea jocului
In ceea ce priveste organizarea dezvoltarii, au fost programate call-uri pe skype pentru a stabili tematica, flow-ul si detaliile jocului.

In cadrul primei discutii am construit o lista de task-uri necesare pentru prima varianta a jocului, iar fiecare membru al echipei si-a ales ce task-uri a vrut sa implementeze.

Pentru source control am folosit GitHub. Pentru dezvoltarea componentelor complexe am folosit diferite branch-uri, pe care le-am unit pe masura ce fiecare task ajungea sa fie implementat si testat.

Testarea a fost manuala, eventualele bug-uri fiind semnalate pe grupul intern al echipei.

Update-uri regulate au fost mentionate pe grupul echipei in legatura cu task-urile implementate, task-urile in lucru si cele ramase.

Din pachetul Endless Runner (1), am folosit elementele de grafica, insa asamblarea lor a fost facuta personal. Am folosit imaginile si obiectele pe care le-am aranjat si generat conform flow-ului jocului nostru.

Denisa s-a ocupat de designul prefabs-urilor pentru harta (cladiri, aranjarea obstacolelor si a power-up-urilor), a scenelor de meniu si game over, cat si de cel al ratonului.

Andreea a implementat miscarea camerei (pozitionare, urmarirea ratonului (3)) si a personajului, dar si o versiune simpla de creare a hartii.

Dragos a adaugat functionalitatile pentru perks si sunetul jocului (4).

Andrei a realizat animatiile de la power-up-uri si interactiunea ratonului cu reward-uri (actualizarea scorului) si cu obstacolele (trimiterea catre ecranul de game over) si a imbunatatit algoritmul de generare a hartii, adaugand object pooling (2) si probabilitati pentru fiecare prefab.

# Referinte
(1) https://assetstore.unity.com/packages/essentials/tutorial-projects/endless-runner-sample-game-87901 

(2) https://www.raywenderlich.com/847-object-pooling-in-unity

(3) https://www.youtube.com/watch?v=7jdL5538bEo&list=PLLH3mUGkfFCXps_IYvtPcE9vcvqmGMpRK 

(4) https://www.youtube.com/watch?v=6OT43pvUyfY