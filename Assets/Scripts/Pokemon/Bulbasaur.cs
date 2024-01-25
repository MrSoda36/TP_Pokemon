using UnityEngine;

public class Bulbasaur : Pokemon
{
    public Bulbasaur() {
        pkmnName = "Bulbizarre";
        maxHp = 120;
        currentHp = maxHp;
        atk = 40;
        def = 60;
        spd = 30;
        type = PokemonType.Grass;
        isKO = false;
        isInPokeball = true;
    }

    public override void AtkSpecial(Pokemon target) {
        Heal();
    }

    public void Heal() {
        if (isInPokeball) {
            Debug.Log("Le " + pkmnName + " de " + originalTrainer.humanName + " est dans sa pokéball");
            return;
        }
        if (isKO) {
            Debug.Log("Le " + pkmnName + " de " + originalTrainer.humanName + " n'est plus en etat de se battre.");
            return;
        }
        Debug.Log("Le " + pkmnName + " de " + originalTrainer.humanName +  " lance Soin");
        currentHp += 30;
    }
}
