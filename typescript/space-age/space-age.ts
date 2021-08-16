export default class SpaceAge {
  constructor(public seconds: number) {}

  public onEarth(): number {
    return this.round(this.seconds / 31557600, 2);
  }

  public onMercury(): number {
    return this.onPlanet(0.2408467);
  }

  public onVenus(): number {
    return this.onPlanet(0.61519726);
  }

  public onMars(): number {
    return this.onPlanet(1.8808158);
  }

  public onJupiter(): number {
    return this.onPlanet(11.862615);
  }

  public onSaturn(): number {
    return this.onPlanet(29.447498);
  }

  public onUranus(): number {
    return this.onPlanet(84.016846);
  }

  public onNeptune(): number {
    return this.onPlanet(164.79132);
  }

  private onPlanet(yearPeriod: number): number {
    return this.round(this.onEarth() / yearPeriod, 2);
  }

  private round(num: number, decimalPlaces: number): number {
    return (
      Math.round(num * Math.pow(10, decimalPlaces)) /
      Math.pow(10, decimalPlaces)
    );
  }
}
