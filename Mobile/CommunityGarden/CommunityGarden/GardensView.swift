import SwiftUI

struct GardensView: View {
    var gardens: Gardens
    var body: some View {
        ZStack {
            NavigationView {
                List {
                    ForEach(gardens.gardens) { garden in
                        Button {
                            Singleton.shared.myGarden = garden
                            Singleton.shared.rootRoute = .gardenMap
                        } label: {
                            VStack {
                                Image("garden\(Int.random(in: 1..<9))")
                                    .resizable()
                                    .scaledToFill()
                                    .padding(0)
                                VStack {
                                    Text(garden.name)
                                        .font(.headline)
                                        .foregroundColor(.white)
                                }
                                .padding(.vertical)
                                .frame(maxWidth: .infinity)
                                .background(Color.accentColor)
                                
                                
                            }
                            .background(Color.accentColor)
                            .clipShape(RoundedRectangle(cornerRadius: 10))
                            .overlay(
                                RoundedRectangle(cornerRadius: 10)
                                 .stroke(Color.accentColor)
                            )
                         
                        }
                    }
                    }
                    .listStyle(.inset)
                    .navigationTitle("Gardens")
                    .navigationBarTitleDisplayMode(.inline)
         
            }
        }
    }
}


//struct GardensView_Previews: PreviewProvider {
//    static var previews: some View {
//        GardensView()
//    }
//}
