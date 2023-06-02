import SwiftUI

struct GardensView: View {
    
    private var gardenNames = ["Garden 1", "Garden 2"]
    var body: some View {
        ZStack {
            NavigationView {
                List {
                    ForEach(gardenNames, id: \.self) { gardenName in
                        NavigationLink(destination: PlantsView()){
                        Text(gardenName)
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


struct GardensView_Previews: PreviewProvider {
    static var previews: some View {
        GardensView()
    }
}
