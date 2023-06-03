//
//  PlantsView.swift
//  CommunityGarden
//
//  Created by Станислав Голя on 02.06.2023.
//

import SwiftUI

struct PlantsView: View {
    @StateObject var singleton = Singleton.shared
    var body: some View {
        ZStack{
            NavigationView{
                VStack{
                    List{
                        ForEach(singleton.myPlants?.plants ?? Plants.init(plants: [Plant(id: "234234")]).plants){ plant in
                            NavigationLink {
                                PlantView(plant: plant)
                            } label: {
                                VStack {
                                    AsyncImage(url: URL(string: plant.imageURL)) { image in
                                        image.resizable()
                                    } placeholder: {
                                        ProgressView()
                                    }
                                        .scaledToFit()
                                        .frame(width: 100, height: 100)
                                        .padding()
                                    
                                    VStack {
                                        Text(plant.name)
                                            .font(.headline)
                                            .foregroundColor(.white)
                                        Text("Need to be watered every \(plant.waterEvery) days")
                                            .font(.body)
                                            .foregroundColor(.white.opacity(0.8))
                                        Text("Planted at \(plant.plantDate)")
                                            .font(.body)
                                            .foregroundColor(.white.opacity(0.8))
                                    }
                                    .padding(.vertical)
                                    .frame(maxWidth: .infinity)
                                    .background(Color.accentColor)
                                    
                                    
                                }
                                .clipShape(RoundedRectangle(cornerRadius: 10))
                                .overlay(
                                    RoundedRectangle(cornerRadius: 10)
                                     .stroke(Color.accentColor)
                                )
                            }
                            
                        }
                    }
                }
                
            }
            
        }
    }
}

struct PlantsView_Previews: PreviewProvider {
    static var previews: some View {
        PlantsView()
    }
}
