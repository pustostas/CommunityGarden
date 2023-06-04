//
//  PlantView.swift
//  CommunityGarden
//
//  Created by Станислав Голя on 02.06.2023.
//

import SwiftUI

struct PlantView: View {
    let plant: Plant
    var body: some View {
        GeometryReader { geometry in
            ScrollView {
                VStack {
                    AsyncImage(url: plant.imageURL) { image in
                        image.resizable()
                    } placeholder: {
                        ProgressView()
                    }
                    .scaledToFit()
                    .frame(maxWidth: geometry.size.width * 0.6)
                    .padding(.top)
                    
                    Text("Was planted: \(plant.plantDate)")
                        .foregroundColor(.white)
                        .padding(.top)
                    
                    VStack(alignment: .leading) {
                        DividerView()
                        Text("Plant Description")
                            .font(.title.bold())
                            .padding(.bottom, 5)
                        
                        Text(plant.description)
                        DividerView()
                        HStack{
                            Spacer()
                        Button("Watch in wiki"){
                            if let url = plant.wikiUrl {
                               UIApplication.shared.open(url)
                            }
                        }.buttonStyle(.borderedProminent)
                            Spacer()
                        }
                        

                        DividerView()
                        
                    }
                    .padding(.horizontal)
                    
                    
                }
                .padding(.bottom)
            }
        }
        .navigationTitle(plant.name)
        .navigationBarTitleDisplayMode(.inline)
    }
    
}


//struct PlantView_Previews: PreviewProvider {
//    static var previews: some View {
//        PlantView(plant: Plant())
//    }
//}
