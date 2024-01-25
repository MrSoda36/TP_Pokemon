using UnityEngine;

public abstract class Pokemon
{
    // Informations de base
    public string pkmnName { get; protected set; }
    public float maxHp { get; protected set; }
    public float currentHp { get; protected set; }
    protected float atk;
    protected int def;
    protected int spd;
    protected PokemonType type;
    public Human originalTrainer { get; protected set; }

    // Etat du pokemon
    public bool isKO { get; protected set; }
    public bool isInPokeball { get; protected set; }

    // Evénements
    public event System.Action<Pokemon> OnKO;

    public void SetOriginalTrainer(Human owner) {
        originalTrainer = owner;
    }

    public void Charge(Pokemon target) {
        if(target == null) {
            Debug.Log("Le " + pkmnName + " de " + originalTrainer.humanName + " n'a pas de cible valide");
            return;
        }
        if (target.originalTrainer == this.originalTrainer) {
            Debug.Log("Le Pokémon ne peut pas se viser soi-même");
        }
        if (isInPokeball) {
            Debug.Log("Le " + pkmnName + " de " + originalTrainer.humanName + " est dans sa pokéball");
            return;
        }
        if(isKO) {
            Debug.Log("Le " + pkmnName + " de " + originalTrainer.humanName + " n'est plus en etat de se battre.");
            return;
        }
        Debug.Log("Le " + pkmnName + " de " + originalTrainer.humanName + " lance Charge");
        target.TakeDamage(atk * 0.2f, PokemonType.Normal);
    }

    public virtual void AtkSpecial(Pokemon target) {
        Debug.Log("Le " + pkmnName + " de " + originalTrainer.humanName + " n'a pas d'attaque spéciale");
    }

    public void TakeDamage(float damage, PokemonType atkType) {
        if (isInPokeball) {
            Debug.Log("Le " + pkmnName + " de " + originalTrainer.humanName + " est dans sa pokéball");
            return;
        }
        if (isKO) {
            Debug.Log("Le " + pkmnName + " de " + originalTrainer.humanName + " n'est plus en etat de se battre.");
            return;
        }
        switch (atkType) {
            case PokemonType.Normal:
                Debug.Log("Le " + pkmnName + " de " + originalTrainer.humanName + " perd " + damage + " de PV");
                currentHp -= damage;
                Debug.Log("Le " + pkmnName + " de " + originalTrainer.humanName + " a " + currentHp + " PV");
                break;
            case PokemonType.Fire:
                if (type == PokemonType.Grass) {
                    Debug.Log("Le " + pkmnName + " de " + originalTrainer.humanName + " perd " + damage * 2 + " de PV");
                    currentHp -= damage * 2;
                    Debug.Log("Le " + pkmnName + " de " + originalTrainer.humanName + " a " + currentHp + " PV");
                } else if (type == PokemonType.Water) {
                    Debug.Log("Le " + pkmnName + " de " + originalTrainer.humanName + " perd " + damage / 2 + " de PV");
                    currentHp -= damage / 2;
                    Debug.Log("Le " + pkmnName + " de " + originalTrainer.humanName + " a " + currentHp + " PV");
                } else {
                    Debug.Log("Le " + pkmnName + " de " + originalTrainer.humanName + " perd " + damage + " de PV");
                    currentHp -= damage;
                    Debug.Log("Le " + pkmnName + " de " + originalTrainer.humanName + " a " + currentHp + " PV");
                }
                break;
            case PokemonType.Water:
                if (type == PokemonType.Fire) {
                    Debug.Log("Le " + pkmnName + " de " + originalTrainer.humanName + " perd " + damage * 2 + " de PV");
                    currentHp -= damage * 2;
                    Debug.Log("Le " + pkmnName + " de " + originalTrainer.humanName + " a " + currentHp + " PV");
                } else if (type == PokemonType.Grass) {
                    Debug.Log("Le " + pkmnName + " de " + originalTrainer.humanName + " perd " + damage / 2 + " de PV");
                    currentHp -= damage / 2;
                    Debug.Log("Le " + pkmnName + " de " + originalTrainer.humanName + " a " + currentHp + " PV");
                } else {
                    Debug.Log("Le " + pkmnName + " de " + originalTrainer.humanName + " perd " + damage + " de PV");
                    currentHp -= damage;
                    Debug.Log("Le " + pkmnName + " de " + originalTrainer.humanName + " a " + currentHp + " PV");
                }
                break;
            case PokemonType.Grass:
                if (type == PokemonType.Water) {
                    Debug.Log("Le " + pkmnName + " de " + originalTrainer.humanName + " perd " + damage * 2 + " de PV");
                    currentHp -= damage * 2;
                    Debug.Log("Le " + pkmnName + " de " + originalTrainer.humanName + " a " + currentHp + " PV");
                } else if (type == PokemonType.Fire) {
                    Debug.Log("Le " + pkmnName + " de " + originalTrainer.humanName + " perd " + damage / 2 + " de PV");
                    currentHp -= damage / 2;
                    Debug.Log("Le " + pkmnName + " de " + originalTrainer.humanName + " a " + currentHp + " PV");
                } else {
                    Debug.Log("Le " + pkmnName + " de " + originalTrainer.humanName + " perd " + damage + " de PV");
                    currentHp -= damage;
                    Debug.Log("Le " + pkmnName + " de " + originalTrainer.humanName + " a " + currentHp + " PV");
                }
                break;
        }
        if (currentHp <= 0) {
            Debug.Log(pkmnName + " est KO");
            isKO = true;
            isInPokeball = true;
            OnKO?.Invoke(this);
        }
    }

    public void ReceiveHeal(float heal) {
        if (isKO) {
            Debug.Log("Le " + pkmnName + " de " + originalTrainer.humanName + " n'est plus en etat de se battre.");
            return;
        }
        if (isInPokeball) {
            Debug.Log("Le " + pkmnName + " de " + originalTrainer.humanName + " est dans sa pokéball");
            return;
        }
        currentHp += heal;
        if (currentHp > maxHp) {
            currentHp = maxHp;
        }
    }

    public void GoInBattle() {
        if (isKO) {
            Debug.Log("Le " + pkmnName + " de " + originalTrainer.humanName + " n'est plus en etat de se battre.");
            return;
        }
        if (isInPokeball) {
            Debug.Log("Le " + pkmnName + " de " + originalTrainer.humanName + " sort de sa pokéball");
            isInPokeball = false;
        }
    }
}

public enum PokemonType {
    Normal,
    Fire,
    Water,
    Grass
}
