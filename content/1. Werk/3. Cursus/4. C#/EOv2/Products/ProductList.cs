using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EOv2.Products
{
    class SupplyKit : Product
    {
        public SupplyKit()
        {
            Name = "Supply kit";
            Category = "Goods";
            Skill = "Engineer";
            SkillLevel = 3;
            DefaultPrice = 40;
            Materials = new Resources(unu: 1, pro: 1);
            Description = "Bevoorrading nodig voor het leven op de kolonie. Een typische bevoorrading bevat allerhande dingen die een kolonist in het dagelijkse leven nodig heeft, van voedselrantsoenen tot diverse veel gebruikte gereedschappen en simpele reserveonderdelen.";
            Physrep = "Een kit met daarin voedselrantsoenen en kleine gereedschappen, survival kit, etc";
        }
    }
    class EnergyCell : Product
    {
        public EnergyCell()
        {
            Name = "Energy cell";
            Category = "Goods";
            Skill = "Chemist";
            SkillLevel = 3;
            DefaultPrice = 200;
            Materials = new Resources(bol:2);
            Description = "Een energy cell is een draagbare krachtige batterij die in korte tijd zeer veel energie kan leveren aan diverse apparaten in het veld. Energycells worden gebruikt om schildgeneratoren van kracht te voorzien. Een vaardig ingenieur kan ook andere projecten van energie voorzien met een energy cell.";
            Physrep = "Een accu of battery pack die aan een schildgenerator gekoppeld kan worden. Een enkele energy cell is ongeveer ter grote van je vuist.";
            Extra = "Gebruikte energy cells verliezen hun waarde en kunnen niet overnieuw opgeladen worden. Lever de kaartjes van gebruikte energy cells in.";
        }
    }
    class RepairKit : Product
    {
        public RepairKit()
        {
            Name = "Repair kit";
            Category = "Goods";
            Skill = "Engineer";
            SkillLevel = 3;
            DefaultPrice = 200;
            Materials = new Resources(unu:1,pro:1);
            Description = "Een repair kit is een handige verzameling van veel gebruikte reserveonderdelen, een breed scala aan draden en diverse elektronische onderdelen. In combinatie met een paar busjes snel uithardende lijmen en polymeer schuimen en de onmisbare rol hitte bestendige tape, is het voor een ingenieur mogelijk om met een repair kit kleine apparaten en voorwerpen te repareren.\nEen vaardig ingenieur kan ook andere toepassingen hebben voor een repair kit, zoals noodreparaties.";
            Physrep = "Een gereedschapskist met diverse technische onderdelen, zoals printplaten, draadjes, schroefjes en moertjes en klein gereedschap om het te assembleren.";
            Extra = "Hoewel een repair kit een breed scala aan diverse types reserve onderdelen bevat, gebruikt je 1 repair kit per reparatie, ongeacht wat voor type voorwerp je repareert. Lever de kaartjes van gebruikte repair kits in.";
        }
    }
    class Stim : Product
    {
        public Stim()
        {
            Name = "Stim (Drug)";
            Category = "Medicine";
            Skill = "Chemist";
            SkillLevel = 5;
            DefaultPrice = 200;
            Materials = new Resources(dal:1,ami:1);
            Description = "Een stim is een medische cocktail van bloedstollers, pijnstillers, hormonen en kunstmatige adrenaline. Een stim herstelt tijdelijk (tot de volgende maaltijd) 2hp op een persoon. Een gemiddeld persoon kan 1 stim per dag aan, maar dit kan verhoogd worden door de vaardigheid uithoudingsvermogen.";
            Physrep = "Een injectiespuit of medisch ampul met daarin een vloeistof.";
            Extra = "Zodra je over je daglimiet van stims heen gaat, val je na 10 minuten bewusteloos aan een overdosis en zal een arts je moeten helpen.";
        }
    }
    class Hybernation : Product
    {
        public Hybernation()
        {
            Name = "Hybernation (Drug)";
            Category = "Medicine";
            Skill = "Chemist";
            SkillLevel = 7;
            DefaultPrice = 400;
            Materials = new Resources(dal: 1, ami: 1);
            Description = "Dit exotische medicijn zorgt ervoor dat je gedurende 10 minuten klinisch dood lijkt. Je lichaam bloedt niet verder, en giffen hebben geen invloed. Je hebt geen meetbare hartslag en je wordt niet geregistreerd door sensoren die levensvormen kunnen detecteren.";
            Physrep = "Een injectiespuit of medisch ampul met daarin een vloeistof.";
            Extra = "Gedurende de 10 minuten dat je klinisch dood lijkt, kan je niets anders doen dan doodstil liggen.";
        }
    }
    class Medicare : Product
    {
        public Medicare()
        {
            Name = "Medicare (Drug)";
            Category = "Medicine";
            Skill = "Chemist";
            SkillLevel = 7;
            DefaultPrice = 500;
            Materials = new Resources(pro: 2, ami: 1);
            Description = "De combinatie van bloedstollers en en diverse pijnstillers hebben op het eerste oog wat weg van stims, maar de medicare cocktail is veel milder voor de patiënt en heeft veel minder extreme bijwerkingen. Vanaf het toedienen van dit medicijn, stopt het doodbloeden voor 10 minuten.";
            Physrep = "Een injectiespuit of medisch ampul met daarin een vloeistof.";
            Extra = "Als het medicijn uitgewerkt is na 10 minuten, gaat het doodbloeden verder waar het gebleven is.";
        }
    }
    class Antibiotics : Product
    {
        public Antibiotics()
        {
            Name = "Antibiotics (Drug)";
            Category = "Medicine";
            Skill = "Chemist";
            SkillLevel = 3;
            DefaultPrice = 400;
            Materials = new Resources(pro:1,bol:2,ami:1);
            Description = "Antibiotica komt in diverse soorten, maar degene die in kolonies en op slagvelden het meest voorkomt is de breedspectrum variant die effectief is tegen zowat alle bacteriële infecties. Deze medicatie wordt gebruikt om acute bacteriologische ziektes te bestrijden.";
            Physrep = "Een injectiespuit of medisch ampul met daarin een vloeistof.";
            Extra = "Werkt niet tegen virale ziektes.";
        }
    }
    class Antiradiation : Product
    {
        public Antiradiation()
        {
            Name = "Antitoxin, radiation (Drug)";
            Category = "Medicine";
            Skill = "Chemist";
            SkillLevel = 3;
            DefaultPrice = 500;
            Materials = new Resources(sur:1,pro:3,ami:1);
            Description = "Straling ligt altijd op de loer in de buurt van grote generatoren en op ruimteschepen. Deze antitoxine helpt zowel bij chronische als bij acute stralingsziekte. Hoewel het niet de schade geneest die al reeds gedaan is, is het wel de eerste stap bij het behandelen van stralingsziekte.";
            Physrep = "Een injectiespuit of medisch ampul met daarin een vloeistof.";
            Extra = "Antitoxines werken alleen tegen een specifieke vergif, in dit geval radioactief materiaal en radioactieve straling.";
        }
    }
    class Antitoxin : Product
    {
        public Antitoxin()
        {
            Name = "Antitoxin, Cholinesterase (Drug)";
            Category = "Medicine";
            Skill = "Chemist";
            SkillLevel = 3;
            DefaultPrice = 500;
            Materials = new Resources(sur: 2, ami: 1, ino: 2);
            Description = "Daar er bij acute vergiftiging vaak te weinig tijd is om de precieze herkomst van de giffen te herleiden, is cholinesterase op de markt gebracht. Deze antitoxine wordt gebruikt als behandeling tegen neurotoxines, apoptose vergiftiging en zware metalen vergiftiging. Alles wat men zo op zou kunnen lopen in een industriële omgeving.";
            Physrep = "Een injectiespuit of medisch ampul met daarin een vloeistof.";
            Extra = "Antitoxines werken alleen tegen een specifieke vergif, in dit geval chemische giffen.";
        }
    }
    class Drill : Product
    {
        public Drill()
        {
            Name = "Drill";
            Category = "Tools";
            Skill = "Engineer";
            SkillLevel = 3;
            DefaultPrice = 400;
            Materials = new Resources(unu:1,sur:1,dal:2);
            Description = "Een drill is het gereedschap wat je in staat stelt om geologische grondstoffen te delven. Geologische drills zijn een losse verzamelterm voor al het industriële gereedschap wat gebruikt wordt om grondstoffen, vaak met bruut geweld, uit de grond te kunnen winnen.";
            Physrep = "Een pneumatische hamer, automatisch pikhouweel of ander groot stuk gereedschap geschikt om mijnschachten te graven. De drill is draagbaar door een enkel persoon, maar is te onhandig om effectief in een gevecht te gebruiken.";
            Extra = "Geologische bots kunnen uitgerust worden met dit gereedschap.";
        }
    }
    class MechTool : Product
    {
        public MechTool()
        {
            Name = "Mech tool";
            Category = "Tools";
            Skill = "Engineer";
            SkillLevel = 4;
            DefaultPrice = 600;
            Materials = new Resources(unu:1,sur:2,dal:2,pro:1);
            Description = "De gereedschappen die een ingenieur nodig kan hebben, zijn talrijk en divers. De ontwikkeling van de veelzijdige mech-tools heeft ervoor gezorgd dat geen monteur of ingenieur ooit nog het probleem heeft van niet het juiste gereedschap bij de hand te hebben.Een Mech Tool is het gereedschap wat je in staat stelt om mechanische handelingen van de vaardigheid ingenieur te gebruiken.";
            Physrep = "Mech-tools zijn erg divers en verschillen per factie. Uiteenlopend van een gereedschapskoffer met allerhande verschillende bijeengeraapte gereedschappen, tot plasma schroevendraaiers met een paar dozijn accessoires en extra functies.";
            Extra = "<VOORSTEL CvK>: Een beginnend personage met ten minste level x ingenieur krijgt de keuze om te starten met een Tech Tool of een Mech Tool.";
        }
    }
    class TechTool : Product
    {
        public TechTool()
        {
            Name = "Tech tool";
            Category = "Tools";
            Skill = "Engineer";
            SkillLevel =3;
            DefaultPrice = 600;
            Materials = new Resources(unu: 1, sur: 2, dal: 2, pro: 1);
            Description = "De gereedschappen die een ingenieur nodig kan hebben, zijn talrijk en divers. De ontwikkeling van de veelzijdige tech-tools heeft ervoor gezorgd dat geen monteur of ingenieur ooit nog het probleem heeft van niet het juiste gereedschap bij de hand te hebben.Een Tech Tool is het gereedschap wat je in staat stelt om mechanische handelingen van de vaardigheid ingenieur te gebruiken.";
            Physrep = "Tech-tools zijn erg divers en verschillen per factie. Uiteenlopend van een gereedschapskoffer met allerhande verschillende bijeengeraapte gereedschappen, tot plasma schroevendraaiers met een paar dozijn accessoires en extra functies.";
            Extra = "<VOORSTEL CvK>: Een beginnend personage met ten minste level x ingenieur krijgt de keuze om te starten met een Tech Tool of een Mech Tool.";
        }
    }
    class ShortWeapon : Product
    {
        public ShortWeapon()
        {
            Name = "Short weapon: 'Falcata'";
            Category = "Melee weapons";
            Skill = "Engineer";
            SkillLevel = 1;
            DefaultPrice = 400;
            Materials = new Resources(unu:2,sur:2);
            Description = "Een kort melee wapen van maximaal 45 cm lang. Er gaat niets boven een goed stuk scherp staal tussen jou en de vijand, en dit soort korte wapens kunnen het verschil tussen leven en dood betekenen.";
            Physrep = "Een veilig LARP wapen van maximaal 45 cm lang totaal ( incluis handvat).";
            Extra = "Dit korte wapen mag je gebruiken als je tenminste niveau 1 hebt in de vaardigheid melee.";
        }
    }
    class MidWeapon : Product
    {
        public MidWeapon()
        {
            Name = "Mid weapon: 'Spathae'";
            Category = "Melee weapons";
            Skill = "Engineer";
            SkillLevel = 3;
            DefaultPrice = 400;
            Materials = new Resources(unu: 1, sur: 1, dal: 2);
            Description = "Een gemiddeld lang melee wapen van maximaal 85 cm lang. De perfecte combinatie van dodelijk en wendbaar, dit type wapens is door de kortere lengte erg populair bij mariniers, die in de nauwe gangen van ruimteschepen langere wapens nauwelijks effectief kunnen gebruiken.";
            Physrep = "Een veilig Larp-wapen van maximaal 85 cm lang totaal (incluis handvat).";
            Extra = "Dit middellange wapen mag je gebruiken als je tenminste niveau 2 hebt in de vaardigheid melee.";
        }
    }
    class LongWeapon : Product
    {
        public LongWeapon()
        {
            Name = "Long weapon: 'Bastard'";
            Category = "Melee weapons";
            Skill = "Engineer";
            SkillLevel = 4;
            Materials = new Resources(unu: 2, sur: 2, dal: 2);
            Description = "Een van de meest traditionele verschijningsvormen van het zwaard, en deze blijft ongekend populair. Dit melee wapen van maximaal 115 cm lang is een wapen wat veel in formele duels gebruikt wordt, maar ook op het slagveld is het terug te vinden als bijvoorbeeld officier wapen.";
            Physrep = "Een veilig Larp-wapen van maximaal 115 cm lang totaal (incluis handvat).";
            Extra = "Dit lange wapen mag je gebruiken als je tenminste niveau 3 hebt in de vaardigheid melee.";
        }
    }
    class TwoHandWeapon : Product
    {
        public TwoHandWeapon()
        {
            Name = "Two-handed weapon: 'Claymore'";
            Category = "Melee weapons";
            Skill = "Engineer";
            SkillLevel = 5;
            Materials = new Resources(unu:1,pro:1);
            Description = "In de lijn “Bigger is better” zijn tweehandige wapens in de handen van een vaardig gebruiker uitermate dodelijk. Een tweehandig melee wapen is maximaal 160 cm lang en moet met twee handen worden gebruikt. Het grotere bereik van dit wapen geeft de gebruiker een duidelijke voorsprong op de tegenstander.";
            Physrep = "Een veilig Larp-wapen van maximaal 160 cm lang totaal (incluis handvat) welke met twee handen gehanteerd moet worden.";
            Extra = "Dit tweehandige wapen mag je gebruiken als je tenminste niveau 4 hebt in de vaardigheid melee.";
        }
    }
    class StaffWeapon : Product
    {
        public StaffWeapon()
        {
            Name = "Staff weapon";
            Category = "Melee weapons";
            Skill = "Engineer";
            SkillLevel = 5;
            DefaultPrice = 600;
            Materials = new Resources(unu:1,sur:1,dal:2,bla:1,ino:1);
            Description = "Stafwapens zijn zowel de moeilijkst te gebruiken melee wapens en tegelijk ook de meest dodelijke in de handen van een meester. Een stafwapen is een melee wapen van maximaal 250 cm lang.";
            Physrep = "Een Larp-veilig wapen van maximaal 250 cm lang totaal, welke met twee handen gehanteerd moet worden.";
            Extra = "Een stafwapen mag je gebruiken als je tenminste niveau 5 hebt in de vaardigheid melee.";
        }
    }
    class Pistol : Product
    {
        public Pistol()
        {
            Name = "Pistol";
            Category = "Firearms";
            Skill = "Engineer";
            SkillLevel = 1;
            DefaultPrice = 300;
            Materials = new Resources(unu:2,sur:1);
            Description = "Een pistool is een niet automatisch vuurwapen met een magazijn van 1-3 patronen. Pistolen zijn de kleinste categorie vuurwapens. Wat ze missen in magazijn formaat en effectief bereik maken ze goed in compact formaat.";
            Physrep = "Een geverfd Nerf wapen met een maximaal magazijn van 3 patronen.";
        }
    }
    class Revolver : Product
    {
        public Revolver()
        {
            Name = "Revolver";
            Category = "Firearms";
            Skill = "Engineer";
            SkillLevel = 3;
            DefaultPrice = 300;
            Materials = new Resources(unu: 2, sur: 1);
            Description = "Een revolver is een niet geautomatiseerd vuurwapen met een magazijn van maximaal 8 kogels.";
            Physrep = "Een geverfd Nerf wapen met een magazijn van maximaal 8 patronen. Nerf wapens met een los magazijn zijn ook toegestaan.";
            Extra = "Dit wapen kan geupgrade worden om automatisch of semi-automatisch te worden.";
        }
    }
    class Rifle : Product
    {
        public Rifle()
        {
            Name = "Rifle";
            Category = "Firearms";
            Skill = "Engineer";
            SkillLevel = 3;
            DefaultPrice = 600;
            Materials = new Resources(unu: 2, sur: 2, dal: 2);
            Description = "Het geweer was vroeger de ruggengraat van het moderne leger, en hoewel automatische versies veel meer vuurkracht geven aan de infanterist, is het veel goedkopere geweer zeker nog niet uitgefaseerd. Een geweer is een niet automatisch vuurwapen met een magazijn van maximaal 18 kogels.";
            Physrep = "Een geverfd nerf wapen met een magazijn van maximaal 18 kogels.";
            Extra = "Dit wapen kan geupgrade worden om automatisch of semi-automatisch te worden.";
        }
    }
    class Carbine : Product
    {
        public Carbine()
        {
            Name = "Carbine";
            Category = "Firearms";
            Skill = "Engineer";
            SkillLevel = 3;
            DefaultPrice = 600;
            Materials = new Resources(unu: 1, sur: 1, dal: 6);
            Description = "Een karabijn is een niet geautomatiseerd vuurwapen met een magazijn van maximaal 26 kogels. Karabijnen zijn verkorte versies van geweren, die tegenwoordig vooral gebruikt worden door wetshandhavers en mariniers. De kortere loop van een karabijn maakt het wapen veel wendbaarder en bruikbaarder in krappe ruimtes of in stedelijke omgevingen.";
            Physrep = "Een geverfd nerf wapen met een magazijn van maximaal 26 kogels.";
            Extra = "Dit wapen kan geupgrade worden om automatisch of semi-automatisch te worden.";
        }
    }
    class MachineGun : Product
    {
        public MachineGun()
        {
            Name = "Machine gun";
            Category = "Firearms";
            Skill = "Engineer";
            SkillLevel = 4;
            DefaultPrice = 600;
            Materials = new Resources(unu: 1, sur: 1, dal: 2, bla: 1);
            Description = "Een niet automatisch vuurwapen met een magazijn van maximaal 35 kogels.";
            Physrep = "Een geverfd Nerf wapen met een magazijn van maximaal 35 kogels.";
            Extra = "Dit wapen kan geupgrade worden om automatisch of semi-automatisch te worden.";
        }
    }
    class Armor : Product
    {
        public Armor()
        {
            Name = "Armor";
            Category = "Protection";
            Skill = "Engineer";
            SkillLevel = 3;
            DefaultPrice = 400;
            Materials = new Resources(dal:4);
            Description = "Een harnas beschermt de drager tegen letsel, en moderne harnassen zijn gemaakt van de sterkste materialen om dit te bewerkstelligen. Een harnas geeft beschermingspunten (AP), afhankelijk van de vaardigheid in bescherming. Het extra gewicht van een harnas kan vrij bewegen echter bemoeilijken.";
            Physrep = "Een harnas bestaat uit verschillende delen, en deze verzameling voor alle lichaamsdelen telt als een enkel harnas. Kogelvrije vesten, keramische platen en exo-skeletten met beplating tellen alleen als harnas.";
            Extra = "Een harnas kan gerepareerd worden met een repair kit.";
        }
    }
    class SemiAutoUpgrade : Product
    {
        public SemiAutoUpgrade()
        {
            Name = "Gun reload semi-automization";
            Category = "Upgrade";
            Skill = "Engineer";
            DefaultPrice = 500;
            Materials = new Resources(unu:1,sur:2,dal:1,pro:1);
            Description = "Dit proces laat toe van een wapen semi-automatisch te maken. De nodige level om dit uit te voeren = de level om het basis wapen te maken + 1 levels.";
            Physrep = "Je moet het wapen zelf OC kunnen voorzien.";
            Extra = "Tijdens de crafting procedure moet je naast het gebruik van de grondstoffen ook een  te modificeren vuurwapen verwerken.";
        }
    }
    class FullAutoUpgrade : Product
    {
        public FullAutoUpgrade()
        {
            Name = "Gun reload automization";
            Category = "Upgrade";
            Skill = "Engineer";
            DefaultPrice = 700;
            Materials = new Resources(unu:2,sur:3,dal:1,pro:1);
            Description = "Dit proces laat toe van een wapen volautomatisch te maken. De nodige level om dit uit te voeren = de level om het basis wapen te maken + 2 levels.";
            Physrep = "Je moet het wapen zelf OC kunnen voorzien.";
            Extra = "Tijdens de crafting procedure moet je naast het gebruik van de grondstoffen ook een  te modificeren vuurwapen verwerken.";
        }
    }
}
