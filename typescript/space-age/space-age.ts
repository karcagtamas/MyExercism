enum PlanetPeriod {
  Mercury = 0.2408467,
  Venus = 0.61519726,
  Mars = 1.8808158,
  Jupiter = 11.862615,
  Saturn = 29.447498,
  Uranus = 84.016846,
  Neptune = 164.79132,
}

const EARTH_YEAR_SECONDS = 31557600;

export default class SpaceAge {
  constructor(public seconds: number) {}

  onEarth(fixed: boolean = true): number {
    return fixed
      ? Number((this.seconds / EARTH_YEAR_SECONDS).toFixed(2))
      : this.seconds / EARTH_YEAR_SECONDS;
  }

  onMercury(): number {
    return this.onPlanet(PlanetPeriod.Mercury);
  }

  onVenus(): number {
    return this.onPlanet(PlanetPeriod.Venus);
  }

  onMars(): number {
    return this.onPlanet(PlanetPeriod.Mars);
  }

  onJupiter(): number {
    return this.onPlanet(PlanetPeriod.Jupiter);
  }

  onSaturn(): number {
    return this.onPlanet(PlanetPeriod.Saturn);
  }

  onUranus(): number {
    return this.onPlanet(PlanetPeriod.Uranus);
  }

  onNeptune(): number {
    return this.onPlanet(PlanetPeriod.Neptune);
  }

  private onPlanet(yearPeriod: number): number {
    return Number((this.onEarth(false) / yearPeriod).toFixed(2));
  }
}
